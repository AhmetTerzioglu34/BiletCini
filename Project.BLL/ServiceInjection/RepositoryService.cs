using Microsoft.Extensions.DependencyInjection;
using Project.DAL.Repositories.Abstracts;
using Project.DAL.Repositories.Concrates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ServiceInjection
{
    public static class RepositoryService
    {
        public static IServiceCollection AddRepositoryService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<IAppUserProfileRepository, AppUserProfileRepository>();
            services.AddScoped<IAppRoleRepository, AppRoleRepository>();
            services.AddScoped<IAppUserRoleRepository, AppUserRoleRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICommentRepository,CommentRepository>();
            services.AddScoped<IMovieCategoryRepository, MovieCategoryRepository>();
            services.AddScoped<IMovieCommentRepository, MovieCommentRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IPlaceRepository, PlaceRepository>();
            services.AddScoped<IScreenRepository, ScreenRepository>();
            services.AddScoped<ISessionRepository, SessionRepository>();
            services.AddScoped<ISessionMovieRepository, SessionMovieRepository>();
            services.AddScoped<ISessionScreenRepository, SessionScreenRepository>();
            services.AddScoped<ISessionTicketRepository, SessionTicketRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            return services;

        }
    }
}
