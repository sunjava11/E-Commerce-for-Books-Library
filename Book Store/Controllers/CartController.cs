using Book_Store.Helpers;
using Book_Store.Models;
using Book_Store.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book_Store.Controllers
{
    public class CartController : Controller
    {
        private bookStoreEntities db = new bookStoreEntities();
        private UserHelper userHelper = new UserHelper();

        //
        // GET: /Cart/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddToCart(int bookId,string requestedAction, string requestedController, int inputCatId=0)
        {

            if(userHelper.IsUserLogin()==false)
            {
                TempData["actionName"] = requestedAction;
                TempData["controllerName"] = requestedController;
                TempData["catId"] = inputCatId;

                return RedirectToAction("Login","Account");
            }

            List<CartViewModel> cartItems = new List<CartViewModel>();

            cartItems = GetCartItems();
            
            

            if (cartItems.Any(k => k.BookId==bookId))
            {
                foreach (var item in cartItems)
                {
                    if (item.BookId == bookId)
                    {
                        item.BookQuantity++;
                        item.SubTotal = item.BookPrice * item.BookQuantity;
                    }
                } 
            }
            else
            {
                Book book = db.Books.Find(bookId);

                CartViewModel cartViewModel = new CartViewModel();
                cartViewModel.BookImageUrl = book.BookImageUrl;
                cartViewModel.BookName = book.Name;
                cartViewModel.BookQuantity = 1;
                cartViewModel.BookId = book.Id;
                cartViewModel.BookPrice = book.Price;
                cartViewModel.SubTotal = cartViewModel.BookPrice * cartViewModel.BookQuantity;
                cartViewModel.BookWeight = book.Weight;

                cartItems.Add(cartViewModel);
            }

            UpdateCartItems(cartItems);

            if (inputCatId != 0)
            {
                return RedirectToAction(requestedAction, requestedController, new { catId = inputCatId });
            }

            return RedirectToAction(requestedAction,requestedController);
        }

        private void UpdateCartItems(List<CartViewModel> cartItems)
        {
            Session["userCart"] = cartItems;
            Session["CartItemCount"] = cartItems.Sum(k => k.BookQuantity);
        }

        public ActionResult ViewCart()
        {

            List<CartViewModel> cartItems = GetCartItems();
            ShippingCharge shippingCharge = db.ShippingCharges.FirstOrDefault();

            decimal totalBookWeight = cartItems.Sum(k => (k.BookWeight*k.BookQuantity));
            decimal subTotal = cartItems.Sum(k => k.SubTotal);
            decimal totalShippingCharges = (totalBookWeight/shippingCharge.Weight) * shippingCharge.ShippingRate;

            ViewData["TotalWeight"] = totalBookWeight;
            ViewData["SubTotal"] = subTotal;
            ViewData["ShippingCharges"] = totalShippingCharges;
            ViewData["NetTotal"] = subTotal + totalShippingCharges;

            return View(cartItems);
        }

        private List<CartViewModel> GetCartItems()
        {
            List<CartViewModel> cartItems = new List<CartViewModel>();
            if (Session["userCart"] != null)
            {
                cartItems = (List<CartViewModel>)Session["userCart"];
            }

            return cartItems;
        }

        public ActionResult Update(int bookId, int Qty)
        {
            List<CartViewModel> cartItems = new List<CartViewModel>();
            cartItems = GetCartItems();

            foreach (var item in cartItems)
            {
                if(item.BookId==bookId)
                {
                    item.BookQuantity = Qty;
                    item.SubTotal = item.BookQuantity * item.BookPrice;
                }
            }

            UpdateCartItems(cartItems);

            return RedirectToAction("ViewCart");
        }

        [HttpGet]
        public ActionResult Checkout()
        {
            List<CartViewModel> cartItems = GetCartItems();
            ShippingCharge shippingCharge = db.ShippingCharges.FirstOrDefault();

            decimal totalBookWeight = cartItems.Sum(k => (k.BookWeight * k.BookQuantity));
            decimal subTotal = cartItems.Sum(k => k.SubTotal);
            decimal totalShippingCharges = (totalBookWeight / shippingCharge.Weight) * shippingCharge.ShippingRate;

            ViewData["TotalWeight"] = totalBookWeight;
            ViewData["SubTotal"] = subTotal;
            ViewData["ShippingCharges"] = totalShippingCharges;
            ViewData["NetTotal"] = subTotal + totalShippingCharges;

            CheckoutViewModel checkoutViewModel = new CheckoutViewModel();
            checkoutViewModel.CartItemsModel = cartItems;


            return View(checkoutViewModel);

        }

        [HttpPost]
        public ActionResult Checkout(CheckoutViewModel checkoutViewModel)
        {
            UserHelper userHelper = new UserHelper();


            ShippingCharge shippingCharge = db.ShippingCharges.FirstOrDefault();
            List<CartViewModel> cartItems = GetCartItems();
            decimal totalBookWeight = cartItems.Sum(k => (k.BookWeight * k.BookQuantity));
            decimal totalShippingCharges = (totalBookWeight / shippingCharge.Weight) * shippingCharge.ShippingRate;



            Order order = new Order();
            order.UserId = userHelper.GetLoginUserId();
            order.Status = "processing";
            order.Createdate = DateTime.Now;
            order.TotalWeight = totalBookWeight;
            order.TotalShippingCharges = totalShippingCharges;
            db.Orders.Add(order);
            db.SaveChanges();

            


            foreach (var item in cartItems)
            {
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.BookId = item.BookId;
                orderDetail.Quantity = item.BookQuantity;
                orderDetail.BookPrice = item.BookPrice;
                orderDetail.BookWeight = item.BookWeight;                
                orderDetail.OrderId = order.OrderId;
                orderDetail.Createdate = DateTime.Now;
                db.OrderDetails.Add(orderDetail);
                db.SaveChanges();
            }

            CustomerDetail customerDetail = new CustomerDetail();
            customerDetail.Customername = checkoutViewModel.CustomerName;
            customerDetail.ShippingAddress = checkoutViewModel.ShippingAddress;
            customerDetail.PhoneNo = checkoutViewModel.PhoneNo;
            customerDetail.OrderId = order.OrderId;
            customerDetail.Createdate = DateTime.Now;
            db.CustomerDetails.Add(customerDetail);
            db.SaveChanges();

            EmptyCart();

            ThankyouViewModel thankyouViewModel = new ThankyouViewModel();
            thankyouViewModel.OrderId = order.OrderId;
            thankyouViewModel.CustomerName = customerDetail.Customername;
            thankyouViewModel.ShippingAddress = customerDetail.ShippingAddress;

            return View("~/Views/Cart/Thankyou.cshtml",thankyouViewModel);
        }

        private void EmptyCart()
        {
            Session.Remove("userCart");
            Session.Remove("CartItemCount");
        }
	}
}