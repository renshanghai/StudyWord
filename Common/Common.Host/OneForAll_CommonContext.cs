using Microsoft.EntityFrameworkCore;
using System;
using Common.Domain;
using Common.Domain.AggregateRoots;
using Common.Host.Providers;

namespace Common.Host
{
    public partial class OneForAll_CommonContext : DbContext
    {
        //private readonly Guid _tenantId;
        public OneForAll_CommonContext(DbContextOptions<OneForAll_CommonContext> options)
            : base(options)
        {

        }
        //public OneForAll_WmsContext(
        //    DbContextOptions<OneForAll_WmsContext> options,
        //    ITenantProvider tenantProvider)
        //    : base(options)
        //{
        //    _tenantId = tenantProvider.GetTenantId();
        //}

        public virtual DbSet<ComHoliday> ComHoliday { get; set; }

        //public virtual DbSet<WmsGoods> WmsGoods { get; set; }

        //public virtual DbSet<WmsGoodsType> WmsGoodsType { get; set; }
        //public virtual DbSet<WmsWarehouse> WmsWarehouse { get; set; }

        //public virtual DbSet<WmsInWarehouse> WmsInWarehouse { get; set; }

        //public virtual DbSet<WmsInWarehouseDetail> WmsInWarehousingDetail { get; set; }
        //public virtual DbSet<WmsInventory> WmsInventory { get; set; }

        //public virtual DbSet<WmsInventoryDetail> WmsInventoryDetail { get; set; }
        //public virtual DbSet<WmsExWarehouse> WmsExWarehouse { get; set; }

        //public virtual DbSet<WmsExWarehouseDetail> WmsExWarehouseDetail { get; set; }
        //public virtual DbSet<WmsAllot> WmsAllot { get; set; }

        //public virtual DbSet<WmsAllotDetail> WmsAllotDetail { get; set; }

        //public virtual DbSet<WmsApply> WmsApply { get; set; }

        //public virtual DbSet<WmsApplyDetail> WmsApplyDetail { get; set; }

        //public virtual DbSet<WmsApplyExContact> WmsApplyExContact { get; set; }

        //public virtual DbSet<WmsCheck> WmsCheck { get; set; }

        //public virtual DbSet<WmsCheckDetail> WmsCheckDetail { get; set; }

        //public virtual DbSet<WmsAmend> WmsAmend { get; set; }

        //public virtual DbSet<WmsAmendDetail> WmsAmendDetail { get; set; }

        //public virtual DbSet<PmsPurchase> PmsPurchase { get; set; }

        //public virtual DbSet<PmsPurchaseDetail> PmsPurchaseDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ComHoliday>(entity =>
            {
                entity.ToTable("Com_Holiday");

                entity.Property(e => e.Id).ValueGeneratedNever();

             //   entity.HasQueryFilter(e => e.TenantId == _tenantId);
            });

            //modelBuilder.Entity<PmsPurchaseDetail>(entity =>
            //{
            //    entity.ToTable("Pms_PurchaseDetail");

            //    entity.Property(e => e.Id).ValueGeneratedNever();
            //});


            //modelBuilder.Entity<WmsSupplier>(entity =>
            //{
            //    entity.ToTable("Wms_Supplier");
            //    entity.Property(e => e.Id).ValueGeneratedNever();

            //    entity.HasQueryFilter(e => e.TenantId == _tenantId);
            //});

            //modelBuilder.Entity<WmsGoods>(entity =>
            //{
            //    entity.ToTable("Wms_Goods");

            //    entity.Property(e => e.Id).ValueGeneratedNever();

            //    entity.HasQueryFilter(e => e.TenantId == _tenantId);

            //    entity.HasOne(d => d.WmsGoodsType)
            //       .WithMany(p => p.WmsGoods)
            //       .HasForeignKey(d => d.WmsGoodsTypeId);
            //});

            //modelBuilder.Entity<WmsGoodsType>(entity =>
            //{
            //    entity.ToTable("Wms_GoodsType");

            //    entity.Property(e => e.Id).ValueGeneratedNever();

            //    entity.HasQueryFilter(e => e.TenantId == _tenantId);
            //});

            //modelBuilder.Entity<WmsWarehouse>(entity =>
            //{
            //    entity.ToTable("Wms_Warehouse");

            //    entity.Property(e => e.Id).ValueGeneratedNever();

            //    entity.HasQueryFilter(e => e.TenantId == _tenantId);
            //});

            //modelBuilder.Entity<WmsInWarehouse>(entity =>
            //{
            //    entity.ToTable("Wms_InWarehouse");

            //    entity.Property(e => e.Id).ValueGeneratedNever();
            //});

            //modelBuilder.Entity<WmsInWarehouseDetail>(entity =>
            //{
            //    entity.ToTable("Wms_InWarehouseDetail");

            //    entity.HasKey(e => new { e.WmsInWarehouseId, e.Code });
            //});

            //modelBuilder.Entity<WmsInventory>(entity =>
            //{
            //    entity.ToTable("Wms_Inventory");

            //    entity.Property(e => e.Id).ValueGeneratedNever();
            //});

            //modelBuilder.Entity<WmsInventoryDetail>(entity =>
            //{
            //    entity.ToTable("Wms_InventoryDetail");
            //    entity.Property(e => e.WmsInventoryId).ValueGeneratedNever();
            //    entity.Property(e => e.Code).ValueGeneratedNever();
            //    entity.HasKey(e => new { e.WmsInventoryId, e.Code });
            //});

            //modelBuilder.Entity<WmsExWarehouse>(entity =>
            //{
            //    entity.ToTable("Wms_ExWarehouse");

            //    entity.Property(e => e.Id).ValueGeneratedNever();
            //});

            //modelBuilder.Entity<WmsExWarehouseDetail>(entity =>
            //{
            //    entity.ToTable("Wms_ExWarehouseDetail");

            //    entity.HasKey(e => new { e.WmsExWarehouseId, e.Code });
            //});
            //modelBuilder.Entity<WmsAllot>(entity =>
            //{
            //    entity.ToTable("Wms_Allot");
            //    entity.Property(e => e.Id).ValueGeneratedNever();

            //    entity.HasQueryFilter(e => e.TenantId == _tenantId);

            //});
            //modelBuilder.Entity<WmsAllotDetail>(entity =>
            //{
            //    entity.ToTable("Wms_AllotDetail");

            //    entity.HasKey(e => new { e.WmsAllotId, e.Code });
            //});
            //modelBuilder.Entity<WmsApply>(entity =>
            //{
            //    entity.ToTable("Wms_Apply");
            //    entity.Property(e => e.Id).ValueGeneratedNever();

            //    entity.HasQueryFilter(e => e.TenantId == _tenantId);

            //});
            //modelBuilder.Entity<WmsApplyDetail>(entity =>
            //{
            //    entity.ToTable("Wms_ApplyDetail");

            //    entity.Property(e => e.Id).ValueGeneratedNever();
            //});
            //modelBuilder.Entity<WmsApplyExContact>(entity =>
            //{
            //    entity.ToTable("Wms_ApplyExContact");

            //    entity.Property(e => e.Id).ValueGeneratedNever();
            //});
            //modelBuilder.Entity<WmsCheck>(entity =>
            //{
            //    entity.ToTable("Wms_Check");

            //    entity.Property(e => e.Id).ValueGeneratedNever();

            //    entity.HasQueryFilter(e => e.TenantId == _tenantId);
            //});
            //modelBuilder.Entity<WmsCheckDetail>(entity =>
            //{
            //    entity.ToTable("Wms_CheckDetail");

            //    entity.Property(e => e.Id).ValueGeneratedNever();
            //});

            //modelBuilder.Entity<WmsAmend>(entity =>
            //{
            //    entity.ToTable("Wms_Amend");

            //    entity.Property(e => e.Id).ValueGeneratedNever();

            //    entity.HasQueryFilter(e => e.TenantId == _tenantId);
            //});

            //modelBuilder.Entity<WmsAmendDetail>(entity =>
            //{
            //    entity.ToTable("Wms_AmendDetail");

            //    entity.HasKey(e => new { e.WmsAmendId, e.Code });
            //});
        }
    }
}
