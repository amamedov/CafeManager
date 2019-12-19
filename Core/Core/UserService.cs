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

        public Order CreateOrder(List<MenuPosition> menuPositions, bool isTakeAway)
        {
            var newOrder = new Order { 
            MenuPositions = menuPositions,
            UserId = user.Id,
            IsTakeAway = isTakeAway
            };
            newOrder.TotalSum = 0;
            foreach(var s in menuPositions)
            {
                newOrder.TotalSum += s.Price;
            }
            var newTransaction = new Transaction { Time = DateTime.Now, Amount = newOrder.TotalSum };
            Add(newTransaction);
            foreach (var m in menuPositions)
            {
                foreach (var i in m.IngredientQuantity)
                {
                    var ingredient = Get<Ingredient>(i.Key);
                    ingredient.QuantityInStorage -= i.Value;
                    Repository.Update(ingredient);
                }
           }
            return newOrder;
        }

        public List<MenuPosition> PossibleChoice()
        {
            var allPositions = Repository.GetAll<MenuPosition>();
            var possibleList = new List<MenuPosition>();
            foreach(var p in allPositions)
            {
                var check = true;
                foreach(var i in p.IngredientQuantity)
                    if (Get<Ingredient>(i.Key).QuantityInStorage < i.Value)
                        check = false;
                if (check == true)
                    possibleList.Add(p);
            }
            return possibleList;
        }

        public bool SignIn(string phone, string password,out string errorMessage, out User user)
        {
            var allUsers = GetAll<User>();
            if (allUsers.Exists(u => u.Phone == phone))
                if (allUsers.Exists(u => u.Phone == phone && u.Password == password))
                {
                    errorMessage = "";
                    user = allUsers.Find(u => u.Phone == phone && u.Password == password);
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

        public FeedBack GiveFeedBack(string message)
        {
            var feedBack = new FeedBack { UserId = user.Id, UsersFeedBack = message };
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
    }
}

