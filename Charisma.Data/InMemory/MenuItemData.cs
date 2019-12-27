using System;
using System.Collections.Generic;
using System.Linq;
using Charisma.Core.Menu;
using Charisma.Data.Data;

namespace Charisma.Data.InMemory
{
    public class MenuItemData : ICharismaData
    {
        public List<IMenuItem> Menu { get; set; }

        public MenuItemData()
        {
            Menu = new List<IMenuItem>()
            {
                new MenuItem(){ Id=1,
                    Name ="Hamnburger", Description ="Burger from ham",
                    ApproximateWaitingTime=new TimeSpan(0,10,0), Fee=300,
                    MainType= MainTypeEnum.MainCourse, SubType= SubTypeEnum.Burger},
                new MenuItem(){ Id=2,
                    Name ="Peperoni", Description ="Pizza with peperoni and onion",
                    ApproximateWaitingTime=new TimeSpan(0,20,0), Fee=600,
                    MainType= MainTypeEnum.MainCourse, SubType= SubTypeEnum.Pizza},
                new MenuItem(){ Id=3,
                    Name ="Holoo", Description ="Fruti Shisha",
                    ApproximateWaitingTime=new TimeSpan(0,5,0), Fee=150,
                    MainType= MainTypeEnum.Shisha, SubType= SubTypeEnum.Shisha},
            };
        }

        public IMenuItem GetById(int id)
        {
            return Menu.Find(m => m.Id == id);
        }

        public IEnumerable<IMenuItem> GetAll(Func<IMenuItem, bool> func = null)
        {
            return func == null ? Menu :
                Menu.Where(func);
        }
    }
}
