using Microsoft.AspNet.Identity;
using Parking.DLL;
using Parking.DLL.Ports;
using Parking.Repository;
using Parking.Repository.Ports;
using Parking.UI.Controllers;
using Parking.UI.Models;
using System;
using System.Data.Entity;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace Parking.UI
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();

            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));
            

            container.RegisterType<BookingRepository>();
            container.RegisterType<CarRepository>();
            container.RegisterType<ConveyorArmsRepository>();
            container.RegisterType<ElevatorRepository>();
            container.RegisterType<FloorRepository>();
            container.RegisterType<PaymentRepository>();
            container.RegisterType<UserRepository>();

            container.RegisterType<IBookingService, BookingService>();
            container.RegisterType<ICarService, CarService>();
            container.RegisterType<IConveyorMovementService, ConveyorMovementService>();
            container.RegisterType<IElevatorService, ElevatorService>();
            container.RegisterType<IFloorService, FloorService>();
            container.RegisterType<IPaymentServices, PaymentService>();
            container.RegisterType<IUserService, UserService>();



            container.RegisterType<DbContext, ApplicationDbContext>(new HierarchicalLifetimeManager());
            container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser>, IUserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<AccountController>(new InjectionConstructor());
        }
    }
}