﻿using Ninject;
using Northwind.Bll.Concrete;
using Northwind.Dal.Concrete.EntityFramework;
using Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Northwind.MvcWebUI.Infrastructure
{
    //Çalışması için, Global.asax içine:

    //ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());

    public class NinjectControllerFactory:DefaultControllerFactory
    {
        private IKernel _ninjectKernel;
        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();

            /* Sistem isteği BLL'e mi yapsın Service'e mi? */
            //AddBllBindings();
            AddServiceBindings();
        }

        private void AddBllBindings()
        {
            //Eğer biri senden IProductService isterse ona ProductManager ver;
            //productDal constructor'ına EfProductDal veriyoruz
            _ninjectKernel.Bind<IProductService>().To<ProductManager>().WithConstructorArgument("productDal",new EfProductDal());

            _ninjectKernel.Bind<ICategoryService>().To<CategoryManager>().WithConstructorArgument("categoryDal", new EfCategoryDal());
            _ninjectKernel.Bind<IAuthenticationService>().To<AuthenticationManager>().WithConstructorArgument("authenticationDal", new EfAuthenticationDal());

            _ninjectKernel.Bind<ICustomerService>().To<CustomerManager>().WithConstructorArgument("customerDal", new EfCustomerDal());
            _ninjectKernel.Bind<IAccountService>().To<AccountManager>().WithConstructorArgument("accountDal", new EfAccountDal());
            _ninjectKernel.Bind<IOrderService>().To<OrderManager>().WithConstructorArgument("orderDal", new EfOrderDal());
            _ninjectKernel.Bind<IOrderDetailService>().To<OrderDetailManager>().WithConstructorArgument("orderDetailDal", new EfOrderDetailDal());
        }

        public void AddServiceBindings()
        {
            //Eğer biri senden IProductService isterse ona,
            //WcfProxy'e git, parametre olarak IProductService ver onun da CreateChannel'ını çalıştır
            _ninjectKernel.Bind<IProductService>().ToConstant(WcfProxy<IProductService>.CreateChannel());

            _ninjectKernel.Bind<ICategoryService>().ToConstant(WcfProxy<ICategoryService>.CreateChannel());
            _ninjectKernel.Bind<IAuthenticationService>().ToConstant(WcfProxy<IAuthenticationService>.CreateChannel());

            _ninjectKernel.Bind<ICustomerService>().ToConstant(WcfProxy<ICustomerService>.CreateChannel());
            _ninjectKernel.Bind<IAccountService>().ToConstant(WcfProxy<IAccountService>.CreateChannel());
            _ninjectKernel.Bind<IOrderService>().ToConstant(WcfProxy<IOrderService>.CreateChannel());
            _ninjectKernel.Bind<IOrderDetailService>().ToConstant(WcfProxy<IOrderDetailService>.CreateChannel());

        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            //Eğer parametreden gelen controllertype null'sa null döndür
            //Değilse _ninjectKernel'den controllerType'ı get et
            //Bütün controller'lar IController interfaceinden türetilir
            return controllerType == null ? null : (IController)_ninjectKernel.Get(controllerType);
        }
    }
}