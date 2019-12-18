using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    interface IUserService
    {
        bool SignIn(string phone, string password, out string errorMessage, out User user);
        bool SignUp(string name, string phone, string password, out string errorMessage, out User user);
        bool GetCurrentOrder(out Order order);
        Order CreateOrder(List<MenuPosition> menuPositions, bool isTakeAway);
        List<MenuPosition> PossibleChoice();
        FeedBack GiveFeedBack(string feedBack);
    }
}
