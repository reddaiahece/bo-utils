using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectsEtl
{
    [FbTable(Description = "Principales")]
    public class PRINCIPALE{
        [FbColumn(DataType = "varchar(64)", IsPrimaryKey = true)]
        public string PRI_CUID;
        [FbColumn(DataType = "varchar(64)", IsPrimaryKey = true)]
        public string PRI_ObjectCUID;
        public string PRI_ObjectKind;
        public string PRI_Role;
        public bool? PRI_IsAdvancedInheritGroups;
        public bool? PRI_IsAdvancedInheritFolders;
    }

    [FbTable(Description = "Principales Role relashionship")]
    public class PRINCIPALROLE{
        [FbColumn(DataType = "varchar(64)", IsPrimaryKey = true)] //, FkConstraint = "PRINCIPALE.PRI_CUID"
        public string PRI_CUID;
        [FbColumn(DataType = "varchar(64)", IsPrimaryKey = true)] //, FkConstraint = "PRINCIPALE.PRI_OBJECTCUID"
        public string PRI_ObjectCUID;
        public string PRI_ObjectKind;
        [FbColumn(DataType = "varchar(64)", IsPrimaryKey = true, FkConstraint = "ROLE.ROL_CUID")]
        public string ROL_CUID;
    }

    [FbTable(Description = "Principal Rights")]
    public class PRINCIPALRIGHT{
        [FbColumn( IsPrimaryKey = true, AutoIncrement=true)]
        public int PRT_ID;
        [FbColumn(DataType = "varchar(64)")]
        public string PRI_CUID;
        public string PRT_ObjectCUID;
        public string PRI_ObjectKind;
        public string PRT_Right;
        public string PRT_ApplicableKind;
        public bool PRT_Denied;
        public string PRT_ObjectKind;
        public bool PRT_Owner;
        public string PRT_Scope;
    }

    [FbTable(Description="Roles")]
    public class ROLE{
        [FbColumn(DataType = "varchar(64)", IsPrimaryKey = true)]
        public string ROL_CUID;
        public int? ROL_ID;
        public string ROL_Name;
        public string ROL_Description;
        public DateTime? ROL_CreationTime;
        public DateTime? ROL_UpdateTime;
    }

    [FbTable(Description = "Role Rights")]
    public class ROLERIGHT{
        [FbColumn( IsPrimaryKey = true, AutoIncrement=true)]
        public int RRT_ID;
        [FbColumn(DataType = "varchar(64)")] //, FkConstraint = "ROLE.ROL_CUID"
        public string ROL_CUID;
        public string RRT_Right;
        public bool? RRT_Granted;
        public string RRT_Kind;
        public bool? RRT_Owner;
        public string RRT_Scope;
    }

    [FbTable(Description = "Inboxes")]
    public class INBOXE {
        [FbColumn(DataType = "varchar(64)", IsPrimaryKey = true)]
        public string INB_CUID;
        public int INB_ID;
        public string INB_Name;
        public string INB_Description;
        public DateTime INB_CreationTime;
        public DateTime INB_UpdateTime;
    }

    [FbTable(Description = "Profiles")]
    public class PROFILE {
        [FbColumn(DataType = "varchar(64)", IsPrimaryKey = true)]
        public string PRO_CUID;
        public int PRO_ID;
        public string PRO_Name;
        public string PRO_Description;
        public DateTime PRO_CreationTime;
        public DateTime PRO_UpdateTime;
    }

    [FbTable(Description="Users")]
    public class USERS{
        [FbColumn(DataType = "varchar(64)", IsPrimaryKey = true)]
        public string USR_CUID;
        public int?    USR_ID;
        public string USR_Name;
        public string USR_FullName;
        public string USR_Description;
        public string USR_EmailAddress;
        public DateTime? USR_CreationTime;
        public DateTime? USR_LastLogonTime;
        public DateTime? USR_UpdateTime;
    }

    [FbTable(Description="Groups")]
    public class GROUPS{
        [FbColumn(DataType = "varchar(64)", IsPrimaryKey = true)]
        public string GRP_CUID;
        public int?    GRP_ID;
        public string GRP_Name;
        public string GRP_Description;
        public DateTime? GRP_CreationTime;
        public DateTime? GRP_UpdateTime;
        public string GRP_ParentCUID;
    }

    [FbTable(Description="Group-User relationship")]
    public class GRP_USR{
        [FbColumn(DataType = "varchar(64)", IsPrimaryKey = true)] //, FkConstraint = "USERS.USR_CUID"
        public string USR_CUID;
        [FbColumn(DataType = "varchar(64)", IsPrimaryKey = true)] //, FkConstraint = "GROUPS.GRP_CUID"
        public string GRP_CUID;
    }

    [FbTable(Description="Categories")]
    public class CATEGORY{
        [FbColumn(DataType = "varchar(64)", IsPrimaryKey = true)]
        public string CAT_CUID;
        public int?    CAT_ID;
        public string CAT_Name;
        public string CAT_Description;
        public DateTime? CAT_CreationTime;
        public string CAT_Path;
        public string CAT_Kind;
        public int? CAT_Instances;
        public string CAT_ParentCUID;
        public string CAT_Owner;
        [FbColumn(DataType = "varchar(64)", FkConstraint = "USERS.USR_CUID")]
        public string USR_CUID;
    }

    [FbTable(Description="Category-Document relationship")]
    public class CAT_DOC{
        [FbColumn(DataType = "varchar(64)", IsPrimaryKey = true)] //, FkConstraint = "CATEGORY.CAT_CUID"
        public string CAT_CUID;
        [FbColumn(DataType = "varchar(64)", IsPrimaryKey = true)] //, FkConstraint = "DOC.DOC_CUID")
        public string DOC_CUID;
    }

    [FbTable(Description="Folders")]
    public class FOLDER{
        [FbColumn(DataType = "varchar(64)", IsPrimaryKey = true)]
        public string FOL_CUID;
        [FbColumn(DataType = "varchar(64)")]
        public string FOL_ParentCUID;
        public int?    FOL_ID;
        public string FOL_Kind;
        public string FOL_Name;
        public string FOL_Description;
        public DateTime? FOL_CreationTime;
        [FbColumn(DataType = "varchar(1024)")]
        public string FOL_Path;
        [FbColumn(DataType = "varchar(64)")]
        public string USR_CUID;
        public string FOL_Owner;
    }

    [FbTable(Description="Universes")]
    public class UNIVERSE{
        [FbColumn(DataType = "varchar(64)", IsPrimaryKey = true)]
        public string UNI_CUID;
        public int?    UNI_ID;
        public string UNI_Kind;
        public string UNI_Name;
        public string UNI_Description;
        public DateTime? UNI_CreationTime;
        [FbColumn(DataType = "varchar(64)")]
        public string USR_CUID;
        public DateTime? UNI_UpdateTime;
        public int? UNI_RevisionNumber;
        public string FOL_CUID;
    }

    [FbTable(Description="Universe-Connection relationship")]
    public class UNI_CON{
        [FbColumn(DataType = "varchar(64)", IsPrimaryKey = true)] //, FkConstraint = "UNIVERSE.UNI_CUID"
        public string UNI_CUID;
        [FbColumn(DataType = "varchar(64)", IsPrimaryKey = true)] //, FkConstraint = "CONNECTION.CON_CUID"
        public string CON_CUID;
    }

    [FbTable(Description="Connections")]
    public class CONNECTION{
        [FbColumn(DataType = "varchar(64)", IsPrimaryKey = true)]
        public string CON_CUID;
        [FbColumn(DataType = "varchar(64)")]
        public string CON_ParentCUID;
        public string CON_Kind;
        public int?   CON_ID;
        public string CON_Name;
        public string CON_Description;
        public int? CON_ObjVerson;
        public int? CON_BVKind;
        public string CON_NetworkLayer;
        public string CON_Database;
        public string CON_Provider;
        public string CON_Catalog;
        public string CON_Cube;
        public DateTime? CON_UpdateTime;
        public DateTime CON_CreationTime;
        public string CON_Owner;
    }

    [FbTable(Description="Connection-Document relationship")]
    public class DOC_CON{
        [FbColumn(DataType = "varchar(64)", IsPrimaryKey = true)] //, FkConstraint = "DOCUMENT.DOC_CUID"
        public string DOC_CUID;
        [FbColumn(DataType = "varchar(64)", IsPrimaryKey = true)] //, FkConstraint = "CONNECTION.CON_CUID"
        public string CON_CUID;
    }

    [FbTable(Description="Documents")]
    public class DOCUMENT{
        [FbColumn(DataType = "varchar(64)", IsPrimaryKey=true)]
        public string DOC_CUID;
        [FbColumn(DataType = "varchar(64)")]
        public string FOL_CUID;
        [FbColumn(DataType = "varchar(64)")] //, FkConstraint = "USERS.USR_CUID"
        public string USR_CUID;
        public int? DOC_ID;
        public string DOC_Kind;
        public string DOC_Name;
        [FbColumn(DataType = "varchar(1024)")]
        public string DOC_Description;
        public DateTime? DOC_CreationTime;
        public long? DOC_ChildrenObjects;
        [FbColumn(DataType = "varchar(1024)")]
        public string DOC_ErrorMessage;
        public int? DOC_UiStatus;
        public DateTime? DOC_UpdateTime;
        [FbColumn(DataType = "varchar(64)")]
        public string DOC_LastSuccessfulInstanceCUID;
    }

    [FbTable(Description="Instances")]
    public class INSTANCE{
        [FbColumn(DataType = "varchar(64)", IsPrimaryKey = true)]
        public string INS_CUID;
        [FbColumn(DataType = "varchar(64)")]
        public string INS_ParentCUID;
        public int? INS_ID;
        public string INS_Name;
        [FbColumn(DataType = "varchar(1024)")]
        public string INS_Description;
        [FbColumn(DataType = "varchar(64)")] //, FkConstraint = "USERS.USR_CUID"
        public string USR_CUID;
        public DateTime? INS_CreationTime;
        public bool? INS_IsRecurring;
        [FbColumn(DataType = "varchar(1024)")]
        public string INS_ErrorMessage;
        public DateTime? INS_NextRunTime;
        public DateTime? INS_StartTime;
        public string INS_Kind;
        public int? INS_UiStatus;
        public DateTime? INS_UpdateTime;
        public DateTime? SCI_BeginDate;
        public DateTime? SCI_EndDate;
        public bool? SCI_RightNow;
        public bool? SCI_Cleanup;
        public string SCI_ScheduleType;
        public int? SCI_RetriesAttempted;
        public int? SCI_RetryInterval;
        [FbColumn(DataType = "varchar(1024)")]
        public string SCI_ErrorMessage;
        public string SCI_SubmitterID;
        public int? SCI_RetriesAllowed;
        public string SCI_Outcome;
        public string SCI_Status;
        public string SCI_Destinations;
    }

    [FbTable(Description="Schedule Info")]
    public class SCHEDULEINFO{
        [FbColumn(DataType = "varchar(64)", IsPrimaryKey = true)]
        public string INS_CUID;
    }

    [FbTable(Description = "ScheduleInfo - Schedule for")]
    public class SCHEDULEFOR {
        [FbColumn(DataType = "varchar(64)", IsPrimaryKey = true)]
        public string INS_CUID;
        [FbColumn(DataType = "varchar(64)", IsPrimaryKey = true)]
        public string USR_CUID;

    }

    [FbTable(Description="Document-Universe relationship")]
    public class UNI_DOC{
        [FbColumn(DataType = "varchar(64)", IsPrimaryKey = true)] //, FkConstraint = "DOCUMENT.DOC_CUID")
        public string DOC_CUID;
        [FbColumn(DataType = "varchar(64)", IsPrimaryKey = true)] //, FkConstraint = "UNIVERSE.UNI_CUID"
        public string UNI_CUID;
    }


}
