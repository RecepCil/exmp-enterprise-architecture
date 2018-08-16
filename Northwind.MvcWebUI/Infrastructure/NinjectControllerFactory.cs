using Ninject;
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
            AddBllBindings();
        }

        private void AddBllBindings()
        {
            //Eğer biri senden IProductService isterse ona ProductManager ver;
            //productDal constructor'ına EfProductDal veriyoruz
            _ninjectKernel.Bind<IProductService>().To<ProductManager>().WithConstructorArgument("productDal",new EfProductDal());

            _ninjectKernel.Bind<ICategoryService>().To<CategoryManager>().WithConstructorArgument("categoryDal", new EfCategoryDal());
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