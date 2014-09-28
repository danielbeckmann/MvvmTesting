using App.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace App.Tests
{
    [TestClass]
    public class MainViewModelTests
    {
        [TestMethod]
        public void SetName_PropertyChangedEventShouldGetInvoked()
        {
            var viewModel = new MainViewModel();
            AssertHelper.PropertyChangedEvent(viewModel, x => x.Name, () => viewModel.Name = "#");
        }

        [TestMethod]
        public void SetName_ValueShouldBeSet()
        {
            var viewModel = new MainViewModel();
            viewModel.Name = "Test";
            Assert.AreEqual("Test", viewModel.Name);
        }

        [TestMethod]
        public void MyCommand_ValuesSet_ShouldRaiseExecuteChanged()
        {
            var viewModel = new MainViewModel();
            AssertHelper.CanExecuteChangedEvent(viewModel.MyCommand, () => viewModel.Name = "#");
        }

        [TestMethod]
        public void MyMethod_EmptyParameter_ShouldThrowArgumentNullException()
        {
            var viewModel = new MainViewModel();
            AssertHelper.ExpectedException<ArgumentNullException>(() => viewModel.MyMethod(null));
        }
    }
}
