using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEDC.ERestaurant.Business.Model;
using SEDC.ERestaurant.Business.Service;
using SEDC.ERestaurant.Data.Model;
using System.Linq;

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
            var resultOne = menuService.Add(menu);
            var resultThree = menuService.Add(menu2);

            var result = menuService.LoadAll();


            //assert

            Assert.IsNotNull(resultThree);
            Assert.IsTrue(resultThree.Success);
            Assert.IsNotNull(resultOne);
            Assert.IsTrue(resultOne.Success);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.ListItems);
            Assert.IsTrue(result.ListItems.Any());


        }
    }
}
