using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEDC.ERestaurant.Business.Model;
using SEDC.ERestaurant.Business.Service;
using SEDC.ERestaurant.Data.Model;

namespace UnitTest.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddMenu_ValidInput_ExpectTwoitems()
        {
            //Act
            DtoMenu menu = new DtoMenu()
            {
                TypeOfMenu = MenuType.Meals,
                RestaurantName = "seavus restaurant",
            };
            DtoMenu menu2 = new DtoMenu()
            {
                TypeOfMenu = MenuType.Meals,
                RestaurantName = "seavus restaurant",
            };


            var menuService = new MenuServices();
            menuService.Add(menu);
            menuService.Add(menu2);

            var result = menuService.LoadAll();


            //assert

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
        }
    }
}
