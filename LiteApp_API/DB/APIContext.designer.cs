﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace LiteApp_API.DB
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="APIContext")]
	public partial class APIContextDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region 可扩展性方法定义
    partial void OnCreated();
    partial void InsertEntries(Entries instance);
    partial void UpdateEntries(Entries instance);
    partial void DeleteEntries(Entries instance);
    partial void InsertUsers(Users instance);
    partial void UpdateUsers(Users instance);
    partial void DeleteUsers(Users instance);
    #endregion
		
		public APIContextDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["APIContextConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public APIContextDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public APIContextDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public APIContextDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public APIContextDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Entries> Entries
		{
			get
			{
				return this.GetTable<Entries>();
			}
		}
		
		public System.Data.Linq.Table<Users> Users
		{
			get
			{
				return this.GetTable<Users>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Entries")]
	public partial class Entries : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _UserId;
		
		private string _Date;
		
		private string _LiuShuiH;
		
		private string _ChiMa;
		
		private string _ShiShu;
		
		private string _BeiZhu;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnDateChanging(string value);
    partial void OnDateChanged();
    partial void OnLiuShuiHChanging(string value);
    partial void OnLiuShuiHChanged();
    partial void OnChiMaChanging(string value);
    partial void OnChiMaChanged();
    partial void OnShiShuChanging(string value);
    partial void OnShiShuChanged();
    partial void OnBeiZhuChanging(string value);
    partial void OnBeiZhuChanged();
    #endregion
		
		public Entries()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL")]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Date", DbType="NVarChar(MAX)")]
		public string Date
		{
			get
			{
				return this._Date;
			}
			set
			{
				if ((this._Date != value))
				{
					this.OnDateChanging(value);
					this.SendPropertyChanging();
					this._Date = value;
					this.SendPropertyChanged("Date");
					this.OnDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LiuShuiH", DbType="NVarChar(MAX)")]
		public string LiuShuiH
		{
			get
			{
				return this._LiuShuiH;
			}
			set
			{
				if ((this._LiuShuiH != value))
				{
					this.OnLiuShuiHChanging(value);
					this.SendPropertyChanging();
					this._LiuShuiH = value;
					this.SendPropertyChanged("LiuShuiH");
					this.OnLiuShuiHChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ChiMa", DbType="NVarChar(MAX)")]
		public string ChiMa
		{
			get
			{
				return this._ChiMa;
			}
			set
			{
				if ((this._ChiMa != value))
				{
					this.OnChiMaChanging(value);
					this.SendPropertyChanging();
					this._ChiMa = value;
					this.SendPropertyChanged("ChiMa");
					this.OnChiMaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ShiShu", DbType="NVarChar(MAX)")]
		public string ShiShu
		{
			get
			{
				return this._ShiShu;
			}
			set
			{
				if ((this._ShiShu != value))
				{
					this.OnShiShuChanging(value);
					this.SendPropertyChanging();
					this._ShiShu = value;
					this.SendPropertyChanged("ShiShu");
					this.OnShiShuChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BeiZhu", DbType="NVarChar(MAX)")]
		public string BeiZhu
		{
			get
			{
				return this._BeiZhu;
			}
			set
			{
				if ((this._BeiZhu != value))
				{
					this.OnBeiZhuChanging(value);
					this.SendPropertyChanging();
					this._BeiZhu = value;
					this.SendPropertyChanged("BeiZhu");
					this.OnBeiZhuChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Users")]
	public partial class Users : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _WX_OpenID;
		
		private string _XingMing;
		
		private string _ShouJiH;
		
		private string _GongZhong;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnWX_OpenIDChanging(string value);
    partial void OnWX_OpenIDChanged();
    partial void OnXingMingChanging(string value);
    partial void OnXingMingChanged();
    partial void OnShouJiHChanging(string value);
    partial void OnShouJiHChanged();
    partial void OnGongZhongChanging(string value);
    partial void OnGongZhongChanged();
    #endregion
		
		public Users()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WX_OpenID", DbType="NVarChar(MAX)")]
		public string WX_OpenID
		{
			get
			{
				return this._WX_OpenID;
			}
			set
			{
				if ((this._WX_OpenID != value))
				{
					this.OnWX_OpenIDChanging(value);
					this.SendPropertyChanging();
					this._WX_OpenID = value;
					this.SendPropertyChanged("WX_OpenID");
					this.OnWX_OpenIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_XingMing", DbType="NVarChar(MAX)")]
		public string XingMing
		{
			get
			{
				return this._XingMing;
			}
			set
			{
				if ((this._XingMing != value))
				{
					this.OnXingMingChanging(value);
					this.SendPropertyChanging();
					this._XingMing = value;
					this.SendPropertyChanged("XingMing");
					this.OnXingMingChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ShouJiH", DbType="NVarChar(MAX)")]
		public string ShouJiH
		{
			get
			{
				return this._ShouJiH;
			}
			set
			{
				if ((this._ShouJiH != value))
				{
					this.OnShouJiHChanging(value);
					this.SendPropertyChanging();
					this._ShouJiH = value;
					this.SendPropertyChanged("ShouJiH");
					this.OnShouJiHChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GongZhong", DbType="NVarChar(MAX)")]
		public string GongZhong
		{
			get
			{
				return this._GongZhong;
			}
			set
			{
				if ((this._GongZhong != value))
				{
					this.OnGongZhongChanging(value);
					this.SendPropertyChanging();
					this._GongZhong = value;
					this.SendPropertyChanged("GongZhong");
					this.OnGongZhongChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591