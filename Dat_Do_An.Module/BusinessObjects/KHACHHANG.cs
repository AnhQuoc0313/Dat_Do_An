using Dat_Do_An.Module.BusinessObjects;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Dat_Do_An.Module.Controllers
{
    [DefaultClassOptions]
    [ImageName("BO_Customer")]
    [System.ComponentModel.DisplayName("Khách Hàng")]
    [DefaultProperty("TenKH")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class KHACHHANG : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public KHACHHANG(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        //private string _PersistentProperty;
        //[XafDisplayName("My display name"), ToolTip("My hint message")]
        //[ModelDefault("EditMask", "(000)-00"), Index(0), VisibleInListView(false)]
        //[Persistent("DatabaseColumnName"), RuleRequiredField(DefaultContexts.Save)]
        //public string PersistentProperty {
        //    get { return _PersistentProperty; }
        //    set { SetPropertyValue(nameof(PersistentProperty), ref _PersistentProperty, value); }
        //}

        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}
        private string _MaKH;
        [Size(50), XafDisplayName("Mã Khách Hàng")]
        [RuleRequiredField("KHACHHANG", DefaultContexts.Save, "MAKH khong duoc trong")]
        [RuleUniqueValue, Indexed(Unique = true)]
        public string MaKH
        {
            get { return _MaKH; }
            set { SetPropertyValue<string>(nameof(MaKH), ref _MaKH, value); }
        }


        private string _TenKH;
        [Size(50), XafDisplayName("Tên Khách Hàng")]
        public string TenKH
        {
            get { return _TenKH; }
            set { SetPropertyValue<string>(nameof(TenKH), ref _TenKH, value); }
        }


        private string _DiaChiKH;
        [Size(50), XafDisplayName("Địa Chỉ Khách Hàng")]
        public string DiaChiKH
        {
            get { return _DiaChiKH; }
            set { SetPropertyValue<string>(nameof(DiaChiKH), ref _DiaChiKH, value); }
        }


        private PhoneNumber _SDTKH;
        [XafDisplayName("Số Điện Thoại Khách Hàng")]
        public PhoneNumber SDTKH
        {
            get { return _SDTKH; }
            set { SetPropertyValue<PhoneNumber>(nameof(SDTKH), ref _SDTKH, value); }
        }


        private string _GhiChuKH;
        [Size(50), XafDisplayName("Ghi Chú Khách Hàng")]
        public string GhiChuKH
        {
            get { return _GhiChuKH; }
            set { SetPropertyValue<string>(nameof(GhiChuKH), ref _GhiChuKH, value); }
        }


        private NHOMKHACHHANG _NHOMKHACHHANG;
        [Association("KEY_KH")]
        [Size(50), XafDisplayName("Nhóm Khách Hàng")]
        public NHOMKHACHHANG NHOMKHACHHANG
        {
            get { return _NHOMKHACHHANG; }
            set { SetPropertyValue<NHOMKHACHHANG>(nameof(NHOMKHACHHANG), ref _NHOMKHACHHANG, value); }
        }


        [DevExpress.Xpo.Aggregated, Association("KEY_KHC")]
        public XPCollection<PHIEUCHI> _PHIEUCHI
        {
            get { return GetCollection<PHIEUCHI>(nameof(_PHIEUCHI)); }
        }


        [DevExpress.Xpo.Aggregated, Association("KEY_KHT")]
        public XPCollection<PHIEUTHU> _PHIEUTHU
        {
            get { return GetCollection<PHIEUTHU>(nameof(_PHIEUTHU)); }
        }


        [DevExpress.Xpo.Aggregated, Association("KEY_KHN")]
        public XPCollection<PHIEUNHAP> _PHIEUNHAP
        {
            get { return GetCollection<PHIEUNHAP>(nameof(_PHIEUNHAP)); }
        }

        [DevExpress.Xpo.Aggregated, Association("KEY_KHX")]
        public XPCollection<PHIEUXUAT> _PHIEUXUAT
        {
            get { return GetCollection<PHIEUXUAT>(nameof(_PHIEUXUAT)); }
        }

        [DevExpress.Xpo.Aggregated, Association("KEY_DHKH")]
        public XPCollection<DONHANG> _DONHANG
        {
            get { return GetCollection<DONHANG>(nameof(_DONHANG)); }
        }
    }
}