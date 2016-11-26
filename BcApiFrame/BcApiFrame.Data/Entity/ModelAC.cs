namespace BcApiFrame.Data.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using AppCloud;
    using ApiCloud;
    using System.Reflection;
    using System.Data.Entity.ModelConfiguration;
    using BcApiFrame.Data.Entity.ApiBase;

    public partial class ModelAC : DbContext
    {
        public ModelAC()
            : base("name=ModelAC")
        {
        }

        #region ApiBase_

        public DbSet<BaseFunction> BaseFunction { get; set; }
        public DbSet<BaseRole> BaseRole { get; set; }
        public DbSet<BaseUser> BaseUser { get; set; }
        public DbSet<BaseUserDetail> BaseUserDetail { get; set; }
        public DbSet<BaseApp> BaseApp { get; set; }
        public DbSet<BaseApiRecord> BaseApiRecord { get; set; }

        #endregion

        #region AppCloud_

        //public DbSet<AppCloud_OrgGroupItem> AppCloud_OrgGroupItem { get; set; }
        //public DbSet<AppCloud_AppGroupItem> AppCloud_AppGroupItem { get; set; }
        //public DbSet<AppCloud_Config> AppCloud_Config { get; set; }
        //public DbSet<AppCloud_Baseframe> AppCloud_Baseframe { get; set; }
        #endregion

        #region ApiCloud_

        //public DbSet<ApiCloud_ApiRequestInputItem> ApiCloud_ApiRequestInputItem { get; set; }
        //public DbSet<ApiCloud_ApiResponseOutputItem> ApiCloud_ApiResponseOutputItem { get; set; }
        //public DbSet<ApiCloud_ApiListItem> ApiCloud_ApiListItem { get; set; }
        //public DbSet<ApiCloud_ProjectListItem> ApiCloud_ProjectListItem { get; set; }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BaseFunctionMap());
            modelBuilder.Configurations.Add(new BaseRoleMap());
            modelBuilder.Configurations.Add(new BaseUserMap());
            modelBuilder.Configurations.Add(new BaseUserDetailMap());
            modelBuilder.Configurations.Add(new BaseAppMap());
            modelBuilder.Configurations.Add(new BaseLogMap());
            modelBuilder.Configurations.Add(new BaseApiRecordMap());

            #region ·ÏÆú
            //string mapSuffix = "BcApiFrame.Data.Entity.ApiBase";

            //var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            //    .Where(type => type.Namespace.EndsWith(mapSuffix, StringComparison.OrdinalIgnoreCase))
            //    .Where(type => !String.IsNullOrEmpty(type.Namespace))
            //    .Where(type => type.BaseType != null && type.BaseType.IsGenericType
            //        && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            //foreach (var type in typesToRegister)
            //{
            //    dynamic configurationInstance = Activator.CreateInstance(type);
            //    modelBuilder.Configurations.Add(configurationInstance);
            //} 
            #endregion

            base.OnModelCreating(modelBuilder);
        }




    }
}
