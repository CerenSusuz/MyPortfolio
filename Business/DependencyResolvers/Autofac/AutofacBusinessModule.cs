using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EF.DALs;
using DataAccess.Concrete.Entity_Framework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JWTHelper>().As<ITokenHelper>();

            builder.RegisterType<BlogImageManager>().As<IBlogImageService>().SingleInstance();
            builder.RegisterType<EFBlogImageDAL>().As<IBlogImageDAL>().SingleInstance();

            builder.RegisterType<BlogManager>().As<IBlogService>().SingleInstance();
            builder.RegisterType<EFBlogDAL>().As<IBlogDAL>().SingleInstance();

            builder.RegisterType<CertificateImageManager>().As<ICertificateImageService>().SingleInstance();
            builder.RegisterType<EFCertificateImageDAL>().As<ICertificateImageDAL>().SingleInstance();

            builder.RegisterType<CertificateManager>().As<ICertificateService>().SingleInstance();
            builder.RegisterType<EFCertificateDAL>().As<ICertificateDAL>().SingleInstance();


            builder.RegisterType<ProjectManager>().As<IProjectService>().SingleInstance();
            builder.RegisterType<EFProjectDAL>().As<IProjectDAL>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EFUserDAL>().As<IUserDAL>().SingleInstance();

            builder.RegisterType<CommentManager>().As<ICommentService>().SingleInstance();
            builder.RegisterType<EFCommentDAL>().As<ICommentDAL>().SingleInstance();

            builder.RegisterType<SubjectManager>().As<ISubjectService>().SingleInstance();
            builder.RegisterType<EFSubjectDAL>().As<ISubjectDAL>().SingleInstance();

            builder.RegisterType<PictureManager>().As<IPictureService>().SingleInstance();
            builder.RegisterType<EFPictureDAL>().As<IPictureDAL>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
