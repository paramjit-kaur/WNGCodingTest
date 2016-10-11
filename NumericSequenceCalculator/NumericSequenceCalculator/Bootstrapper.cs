using System.Web.Mvc;
using NumericSequenceCalculator.Models;
using NumericSequenceCalculator.Service;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using NumericSequenceCalculator.Controllers;

namespace NumericSequenceCalculator
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<ISequence, Sequence>(new TransientLifetimeManager());           
            container.RegisterType<ISequenceService, SequenceService>(new TransientLifetimeManager());
            container.RegisterType<IController, HomeController>(new TransientLifetimeManager());
            
            return container;
        }
    }
}