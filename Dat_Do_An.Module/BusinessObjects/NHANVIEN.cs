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
    //[ImageName("BO_Contact")]
    [DefaultProperty("TenNV")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class NHANVIEN : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public NHANVIEN(Session session)
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

        private string _MaNV;
        [Size(50), XafDisplayName("Mã Nhân Viên")]
        [RuleRequiredField("NHANVIEN", DefaultContexts.Save, "MANV khong duoc trong")]
        [RuleUniqueValue, Indexed(Unique = true)]
        public string MaNV
        {
            get { return _MaNV; }
            set { SetPropertyValue<string>(nameof(MaNV), ref _MaNV, value); }
        }

        private string _TaiKhoanNV;
        [Size(50), XafDisplayName("Tài Khoản Nhân Viên")]
        public string TaiKhoanNV
        {
            get { return _TaiKhoanNV; }
            set { SetPropertyValue<string>(nameof(TaiKhoanNV), ref _TaiKhoanNV, value); }
        }



        private string _TenNV;
        [Size(50), XafDisplayName("Tên Nhân Viên")]
        public string TenNV
        {
            get { return _TenNV; }
            set { SetPropertyValue<string>(nameof(TenNV), ref _TenNV, value); }
        }


        private string _DiaChiNV;
        [Size(50), XafDisplayName("Địa Chỉ Nhân Viên")]
        public string DiaChiNV
        {
            get { return _DiaChiNV; }
            set { SetPropertyValue<string>(nameof(DiaChiNV), ref _DiaChiNV, value); }
        }


        private PhoneNumber _SDTNV;
        [XafDisplayName("Số Điện Thoại Nhân Viên")]
        public PhoneNumber SDTNV
        {
            get { return _SDTNV; }
            set { SetPropertyValue<PhoneNumber>(nameof(SDTNV), ref _SDTNV, value); }
        }


        private string _GhiChuNV;
        [Size(50), XafDisplayName("Ghi Chú Nhân Viên")]
        public string GhiChuNV
        {
            get { return _GhiChuNV; }
            set { SetPropertyValue<string>(nameof(GhiChuNV), ref _GhiChuNV, value); }
        }


        [DevExpress.Xpo.Aggregated, Association("KEY_NVC")]
        public XPCollection<PHIEUCHI> _PHIEUCHI
        {
            get { return GetCollection<PHIEUCHI>(nameof(_PHIEUCHI)); }
        }


        [DevExpress.Xpo.Aggregated, Association("KEY_NVT")]
        public XPCollection<PHIEUTHU> _PHIEUTHU
        {
            get { return GetCollection<PHIEUTHU>(nameof(_PHIEUTHU)); }
        }


        [DevExpress.Xpo.Aggregated, Association("KEY_NVN")]
        public XPCollection<PHIEUNHAP> _PHIEUNHAP
        {
            get { return GetCollection<PHIEUNHAP>(nameof(_PHIEUNHAP)); }
        }

        [DevExpress.Xpo.Aggregated, Association("KEY_NVX")]
        public XPCollection<PHIEUXUAT> _PHIEUXUAT
        {
            get { return GetCollection<PHIEUXUAT>(nameof(_PHIEUXUAT)); }
        }
    }
}