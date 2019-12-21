using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace Core
{
    public class UserService : IService
    {
        public dbRepository Repository { get; set; }
        User user;
        public UserService()
        {
            Repository = new dbRepository(new Context());
        }
        public bool GetCurrentOrder(out Order order)
        {
            var allOrders = Repository.GetAll(user);
            order = allOrders.FirstOrDefault(o => o.DeliveryTime == null);
            return order != null;
        }

        public Order CreateOrder(int menuPositionsId, bool isTakeAway)
        {
            var newOrder = new Order
            {
                MenuPositionId = menuPositionsId,
                UserId = user.Id,
                IsTakeAway = isTakeAway
            };
            newOrder.TotalSum = Get<MenuPosition>(menuPositionsId).Price;
            var newTransaction = new Transaction { Time = DateTime.Now, Amount = newOrder.TotalSum };
            Add(newTransaction);
            var ingredient = Get<Ingredient>(Get<MenuIngredient>(Get<MenuPosition>(menuPositionsId).MenuIngredientId).IngredientId);
            ingredient.QuantityInStorage -= Repository.Get<MenuIngredient>(Get<MenuPosition>(menuPositionsId).MenuIngredientId).Quantity;
            Repository.Update(ingredient);
            return newOrder;
        }

        public List<MenuPosition> PossibleChoice()
        {
            var allPositions = Repository.GetAll<MenuPosition>();
            var possibleList = new List<MenuPosition>();
            foreach (var p in allPositions)
            {
                var check = true;
                if (Get<Ingredient>(p.MenuIngredientId).QuantityInStorage < Get<Ingredient>(p.MenuIngredientId).QuantityInStorage)
                    check = false;
                if (check == true)
                    possibleList.Add(p);
            }
            return possibleList;
        }

        public bool SignIn(string phone, string password, out string errorMessage, out User user)
        {
            var allUsers = GetAll<User>();
            if (allUsers.Exists(u => u.Phone == phone))
                if (allUsers.Exists(u => u.Phone == phone && u.Password == password))
                {
                    errorMessage = "";
                    user = allUsers.Find(u => u.Phone == phone && u.Password == password);
                    this.user = user;
                }
                else
                {
                    errorMessage = "Password is incorrect, try again!";
                    user = null;
                }
            else
            {
                errorMessage = "This phone does not exist, try again or sign up!";
                user = null;
            }
            return user != null;
        }

        public bool SignUp(string name, string phone, string password, out string errorMessage, out User user)
        {
            var allUsers = Repository.GetAll<User>();
            if (!allUsers.Exists(u => u.Phone == phone))
            {
                if (password != "")
                {
                    user = new User { Name = name, Phone = phone, Password = password };
                    Add(user);
                    errorMessage = "";
                }
                else
                {
                    user = null;
                    errorMessage = "Password field can't be whitespace";
                }
            }
            else
            {
                user = null;
                errorMessage = "This phone already exists, please try again or sign in using this phone!";
            }
            return user != null;
        }

        public FeedBack GiveFeedBack(string message, User user)
        {
            var feedBack = new FeedBack { UserId = user.Id, UsersFeedBack = message, Seen = false };
            Add(feedBack);
            return feedBack;
        }

        public T Get<T>(int Id) where T : class => Repository.Get<T>(Id);

        public List<T> GetAll<T>() where T : class => Repository.GetAll<T>();

        public void Update<T>(T obj) where T : class
        {
            Repository.Update(obj);
        }

        public void UpdateRange<T>(List<T> obj) where T : class
        {
            Repository.Update(obj);
        }

        public void Add<T>(T obj) where T : class
        {
            Repository.Add(obj);
        }

        public void Logout()
        {
            user = null;
        }
    }
}

