using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    interface IUserService
    {
        bool SignIn(string phone, string password, out User user);
        User SignUp(string name, string phone, string password);
        Order GetCurrentOrder();
        Order MakeOrder(List<MenuPosition> menuPositions);
        List<MenuPosition> PossibleChoice();
    }
}
