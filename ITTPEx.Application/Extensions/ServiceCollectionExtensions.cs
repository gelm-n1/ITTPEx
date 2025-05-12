
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ITTPEx.Application.Behaviors;
using ITTPEx.Application.Features.Roles.Commands.CreateRole;
using FluentValidation;
using ITTPEx.Application.Features.Users.Commands.CreateUser;
using ITTPEx.Application.Features.Users.Commands.Login;
using ITTPEx.Application.Features.Users.Commands.RegisterUser;
using ITTPEx.Application.Features.Users.Commands.AdminUpdateUserProfile;
using ITTPEx.Application.Features.Users.Commands.AdminUpdateUserPassword;
using ITTPEx.Application.Features.Users.Commands.SelfUpdateUserPassword;
using ITTPEx.Application.Features.Users.Queries.GetUserByLogin;
using ITTPEx.Application.Features.Users.Commands.SelfUpdateUserLogin;
using ITTPEx.Application.Features.Roles.Commands.UpdateRoleName;

namespace ITTPEx.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddMediator();
            services.AddServices();
            services.AddValidators();
        }

        private static void AddMediator(this IServiceCollection services) 
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }

        private static void AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateRoleCommand>, CreateRoleValidator>();
            services.AddScoped<IValidator<CreateUserCommand>, CreateUserValidator>();
            services.AddScoped<IValidator<UpdateRoleNameCommand>, UpdateRoleNameValidator>();
            services.AddScoped<IValidator<LoginCommand>, LoginValidator>();
            services.AddScoped<IValidator<RegisterUserCommand>, RegisterUserValidator>();
            services.AddScoped<IValidator<AdminUpdateUserProfileCommand>, AdminUpdateUserProfileValidator>();
            services.AddScoped<IValidator<AdminUpdateUserPasswordCommand>, AdminUpdateUserPasswordValidator>();
            services.AddScoped<IValidator<SelfUpdateUserPasswordCommand>, SelfUpdateUserPasswordValidator>();
            services.AddScoped<IValidator<GetUserByLoginQuery>, GetUserByLoginValidator>();
            services.AddScoped<IValidator<SelfUpdateUserLoginCommand>, SelfUpdateUserLoginValidator>();
        }

        private static void AddServices(this IServiceCollection services)
        {

        }
    }
}
