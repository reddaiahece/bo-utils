extern alias DSWS140;

using System;
using System.Collections.Generic;

using FixedCUIDs = DSWS140::BusinessObjects.DSWS.BIPlatform.Constants.FixedCUIDs;
using ResponseHolder = DSWS140::BusinessObjects.DSWS.BIPlatform.ResponseHolder;
using PagingDetails = DSWS140::BusinessObjects.DSWS.BIPlatform.PagingDetails;
using PageInfo = DSWS140::BusinessObjects.DSWS.BIPlatform.PageInfo;
using InfoObjects = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.InfoObjects;
using InfoObject = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.InfoObject;
using GenericInfoObject = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.GenericInfoObject;
using User = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.User;
using UserGroup = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.UserGroup;
using Category = DSWS140::Custom.Category;
using PersonalCategory = DSWS140::Custom.PersonalCategory;
using Folder = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.Folder;
using FavoritesFolder = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.FavoritesFolder;
using Universe = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.Universe;
using Connection = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.Connection;
using Path = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.Path;
using PathFolder = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.PathFolder;
using Webi = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.Webi;
//using FullClient = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.FullClient;
using CrystalReport = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.CrystalReport;
using Publication = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.Publication;
using CollateralId = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.CollateralId;
using WebiProcessingInfo = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.WebiProcessingInfo;
using CustomProperties = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.CustomProperties;
using CustomRelation = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.CustomRelation;
using CustomPropertiesDouble = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.CustomPropertiesDouble;
using CustomPropertiesString = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.CustomPropertiesString;
using CustomPropertiesBool = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.CustomPropertiesBool;
using CustomPropertiesDate = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.CustomPropertiesDate;
using CustomPropertiesInteger = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.CustomPropertiesInteger;
using GetOptions = DSWS140::BusinessObjects.DSWS.BIPlatform.GetOptions;
//using FullClientDataProvider = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.FullClientDataProvider;
using SecurityInfo = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.SecurityInfo;
using SecurityInfo2 = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.SecurityInfo2;
using Principal = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.Principal;
using RoleEnum = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.RoleEnum;
using CustomRole = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.CustomRole;
using Role = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.Role;
using Right = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.Right;
using RightInfo = DSWS140::BusinessObjects.DSWS.BIPlatform.RightInfo;
using Profile = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.Profile;
using Inbox = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.Inbox;
using SystemRightEnum = DSWS140::BusinessObjects.DSWS.BIPlatform.Rights.SystemRightEnum;
using Designer_RightEnum = DSWS140::BusinessObjects.DSWS.BIPlatform.Rights.Designer_RightEnum;
using InfoView_RightEnum = DSWS140::BusinessObjects.DSWS.BIPlatform.Rights.InfoView_RightEnum;
using Event_RightEnum = DSWS140::BusinessObjects.DSWS.BIPlatform.Rights.Event_RightEnum;
using CrystalReport_RightEnum = DSWS140::BusinessObjects.DSWS.BIPlatform.Rights.CrystalReport_RightEnum;
using BIWidgets_RightEnum = DSWS140::BusinessObjects.DSWS.BIPlatform.Rights.BIWidgets_RightEnum;
using Universe_RightEnum = DSWS140::BusinessObjects.DSWS.BIPlatform.Rights.Universe_RightEnum;
using Webi_RightEnum = DSWS140::BusinessObjects.DSWS.BIPlatform.Rights.Webi_RightEnum;
using RoleRight = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.RoleRight;
using SchedulingInfo = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.SchedulingInfo;
using ObjectPackage = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.ObjectPackage;
using Pdf = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.Pdf;
using Excel = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.Excel;
using Word = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.Word;
using Powerpoint = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.Powerpoint;
using Destination = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.Destination;
using DestinationScheduleOptions = DSWS140::BusinessObjects.DSWS.BIPlatform.Desktop.DestinationScheduleOptions;
using DiskUnmanagedScheduleOptions = DSWS140::BusinessObjects.DSWS.BIPlatform.Dest.DiskUnmanagedScheduleOptions;
using ManagedScheduleOptions = DSWS140::BusinessObjects.DSWS.BIPlatform.Dest.ManagedScheduleOptions;
using FtpScheduleOptions = DSWS140::BusinessObjects.DSWS.BIPlatform.Dest.FtpScheduleOptions;
using SMTPScheduleOptions = DSWS140::BusinessObjects.DSWS.BIPlatform.Dest.SMTPScheduleOptions;
//using MetaDataDataConnection = DSWS140::BusinessObjects.DSWS.BIPlatform.Metadata.MetaDataDataConnection;

using BusinessObjectsEtl;

//http://publib.boulder.ibm.com/infocenter/radhelp/v7r5/index.jsp?topic=%2Fcom.businessobjects.integration.eclipse.devtools.doc%2Fdeveloper%2FEnterpriseRepositoryView10.html
//http://book.soundonair.ru/sams/ch30lev1sec5.html
//http://scn.sap.com/thread/1977590
//http://code.google.com/p/sap-sinopec/
//http://scn.sap.com/message/10376042
//http://scn.sap.com/thread/1618922

namespace BusinessObjectsEtl
{
    public class Etl140 : Session140{

        IDataBase[] databases;
        //int principalId = 0;
        int rightId = 0;

        public Etl140(string sessionURL) : base(sessionURL) { }

        public void SetDatabase(IDataBase[] databases){
            this.databases = databases;
        }

        public bool GetInboxes(){
            bool succeed = true;
            List<INBOXE> objInboxes = new List<INBOXE>();
            string[] select = new string[]{
                    "SI_CUID", "SI_ID", "SI_PARENT_GUID", "SI_NAME", "SI_DESCRIPTION", "SI_CREATION_TIME",
                    "SI_UPDATE_TS"
                };
            base.Log("Extract Inbox from web service");
            List<InfoObject> infoObjects = null;
            succeed &= GetObjects(out infoObjects, "query://{SELECT " + String.Join(",", select) + " FROM CI_INFOOBJECTS WHERE SI_KIND='Inbox'}" );
            foreach(InfoObject infoObject in infoObjects){
                Inbox userGroup = (Inbox)infoObject;
                objInboxes.Add( new INBOXE{
                    INB_CUID = infoObject.CUID,
                    INB_ID = infoObject.ID,
                    INB_Name = infoObject.Name,
                    INB_Description = infoObject.Description,
                    INB_CreationTime = userGroup.CreationTime.ToLocalTime(),
                    INB_UpdateTime = userGroup.UpdateTime
                });
            }
            foreach(IDataBase db in databases){
                succeed &= db.InsertObjects(objInboxes);
            }
            return succeed;
        }

        public bool GetProfiles(){
            bool succeed = true;
            List<PROFILE> objProfiles = new List<PROFILE>();
            string[] select = new string[]{
                    "SI_CUID", "SI_ID", "SI_PARENT_GUID", "SI_NAME", "SI_DESCRIPTION", "SI_CREATION_TIME", "SI_UPDATE_TS",
                };
            base.Log("Extract Profile from web service");
            List<InfoObject> infoObjects = null;
            succeed &= GetObjects(out infoObjects, "query://{SELECT " + String.Join(",", select) + " FROM CI_SYSTEMOBJECTS WHERE SI_KIND='Profile'}");
            foreach(InfoObject infoObject in infoObjects){
                Profile userGroup = (Profile)infoObject;
                objProfiles.Add( new PROFILE{
                    PRO_CUID = infoObject.CUID,
                    PRO_ID = infoObject.ID,
                    PRO_Name = infoObject.Name,
                    PRO_Description = infoObject.Description,
                    PRO_CreationTime = userGroup.CreationTime.ToLocalTime(),
                    PRO_UpdateTime = userGroup.UpdateTime
                });
            }
            foreach(IDataBase db in databases){
                succeed &= db.InsertObjects(objProfiles);
            }
            return succeed;
        }

        public bool GetRoles(){
            bool succeed = true;
            base.Log("Extract Roles from web service");
            int art_id=0;
            List<ROLE> objAccessLevels = new List<ROLE>();
            List<ROLERIGHT> objAccessRights = new List<ROLERIGHT>();
            string[] select = new string[]{
                    "SI_CUID", "SI_ID", "SI_NAME", "SI_DESCRIPTION", "SI_CREATION_TIME", "SI_UPDATE_TS",
                    "SI_USERGROUPS", "SI_ROLES_ON_OBJECT", "SI_ROLE_RIGHTS", "SI_SYSTEM_RIGHTS", "SI_RIGHTS_FROM_PLUGINS", "SI_OBJECTS_ASSIGNED_ROLE"
                };
            List<InfoObject> infoObjects = null;
            succeed &= GetObjects(out infoObjects, "query://{SELECT " + String.Join(",", select) + " FROM CI_SYSTEMOBJECTS WHERE SI_KIND='CustomRole'}");
            foreach (InfoObject infoObject in infoObjects) {
                CustomRole role = (CustomRole)infoObject;
                ROLE acc = new ROLE {
                    ROL_CUID = infoObject.CUID,
                    ROL_ID = infoObject.ID,
                    ROL_Name = infoObject.Name,
                    ROL_CreationTime = infoObject.CreationTime.ToLocalTime(),
                    ROL_UpdateTime = infoObject.UpdateTime.ToLocalTime(),
                    ROL_Description = infoObject.Description
                };
                if(role.RoleRights != null){
                    foreach(RoleRight roleright in role.RoleRights){
                        string strRole = roleright.Id.ToString();
                        /*switch(roleright.Kind){
                            case "" : strRole = Enum.GetName(typeof(SystemRightEnum), roleright.Id); break;
                            case "Designer": strRole = Enum.GetName(typeof(Designer_RightEnum), roleright.Id); break;
                            case "InfoView": strRole = Enum.GetName(typeof(InfoView_RightEnum), roleright.Id); break;
                            case "Event": strRole = Enum.GetName(typeof(Event_RightEnum), roleright.Id); break;
                            case "CrystalReport": strRole = Enum.GetName(typeof(CrystalReport_RightEnum), roleright.Id); break;
                            case "BIWidgets": strRole = Enum.GetName(typeof(BIWidgets_RightEnum), roleright.Id); break;
                            case "DSL.Universe": strRole = Enum.GetName(typeof(Universe_RightEnum), roleright.Id); break;
                            case "Webi": strRole = Enum.GetName(typeof(Webi_RightEnum), roleright.Id); break;
                        }*/
                        objAccessRights.Add( new ROLERIGHT{
                            ROL_CUID = infoObject.CUID,
                            RRT_ID = ++art_id,
                            RRT_Right = strRole,
                            RRT_Granted = roleright.Granted,
                            RRT_Kind = roleright.Kind,
                            RRT_Owner = roleright.Owner,
                            RRT_Scope = roleright.Scope
                        });
                    }
                }
                objAccessLevels.Add(acc);
            }
            foreach (IDataBase db in databases){
                succeed &= db.InsertObjects(objAccessLevels);
                succeed &= db.InsertObjects(objAccessRights);
            }
            return succeed;
        }

        public bool GetGroups(){
            bool succeed = true;
            base.Log("Extract Groups from web service");
            List<GROUPS> objGroups = new List<GROUPS>();
            List<PRINCIPALE> lstPrincipales = new List<PRINCIPALE>();
            List<PRINCIPALRIGHT> lstRights = new List<PRINCIPALRIGHT>();
            List<PRINCIPALROLE> lstRoles = new List<PRINCIPALROLE>();
            string[] select = new string[]{
                    "SI_CUID", "SI_ID", "SI_PARENT_GUID", "SI_NAME", "SI_DESCRIPTION", "SI_CREATION_TIME", "SI_UPDATE_TS",
                    "SI_PRINCIPAL_PROFILES", "SI_PRINCIPALS", "SI_PROFILE_PRINCIPALS"
                };
            List<InfoObject> infoObjects = null;
            succeed &= GetObjects(out infoObjects, "query://{SELECT " + String.Join(",", select) + " FROM CI_SYSTEMOBJECTS WHERE SI_KIND='UserGroup'}");
            // List<InfoObject> infoObjects = GetObjects("cuid://<" + FixedCUIDs.SystemObject.USERGROUPS + ">/*@SI_CUID,SI_ID,SI_NAME,SI_DESCRIPTION,SI_CREATION_Time,SI_PATH");
            foreach(InfoObject infoObject in infoObjects){
                UserGroup userGroup = (UserGroup)infoObject;
                objGroups.Add( new GROUPS{
                    GRP_CUID = infoObject.CUID,
                    GRP_ID = infoObject.ID,
                    GRP_ParentCUID = infoObject.ParentCUID,
                    GRP_Name = infoObject.Name,
                    GRP_Description = infoObject.Description,
                    GRP_CreationTime = userGroup.CreationTime.ToLocalTime(),
                    GRP_UpdateTime = userGroup.UpdateTime
                });
            }
            GetSecurity(ref infoObjects, ref lstPrincipales, ref lstRights, ref lstRoles);
            foreach(IDataBase db in databases){
                succeed &= db.InsertObjects(objGroups);
                succeed &= db.InsertObjects(lstPrincipales);
                succeed &= db.InsertObjects(lstRights);
                succeed &= db.InsertObjects(lstRoles);
            }
            return succeed;
        }

        public bool GetUsers(){
            bool succeed = true;
            base.Log("Extract Users from web service");
            List<USERS> objUsers = new List<USERS>();
            List<GRP_USR> objGroupUser = new List<GRP_USR>();
            List<PRINCIPALE> lstPrincipales = new List<PRINCIPALE>();
            List<PRINCIPALRIGHT> lstRights = new List<PRINCIPALRIGHT>();
            List<PRINCIPALROLE> lstRoles = new List<PRINCIPALROLE>();
            string[] select = new string[]{
                    "SI_CUID", "SI_ID", "SI_KIND", "SI_NAME", "SI_DESCRIPTION", "SI_CREATION_TIME", "SI_UPDATE_TS",
                    "SI_USERFULLNAME",
                    "SI_USERID",
                    "SI_EMAIL_ADDRESS",
                    "SI_LASTLOGONTIME",
                    "SI_USER_DISABLED",
                    "SI_USERGROUPS"
                };
            List<InfoObject> infoObjects = null;
            succeed &= GetObjects(out infoObjects, "query://{SELECT " + String.Join(",", select) + " FROM CI_SYSTEMOBJECTS WHERE SI_KIND='User'}", true);
            //List<InfoObject> infoObjects = GetObjects("cuid://<" + FixedCUIDs.SystemObject.USERS + ">/*@SI_CUID,SI_ID,SI_USERID,SI_NAME,SI_USERFULLNAME,SI_DESCRIPTION,SI_EMAIL_ADDRESS,SI_CREATION_TIME,SI_LASTLOGONTIME,SI_USERGROUPS");
            foreach(InfoObject infoObject in infoObjects){
                User user = (User)infoObject;
                objUsers.Add( new USERS{
                    USR_CUID = infoObject.CUID,
                    USR_ID = infoObject.ID,
                    USR_Name = infoObject.Name,
                    USR_FullName = user.FullName,
                    USR_Description = infoObject.Description,
                    USR_EmailAddress = user.EmailAddress,
                    USR_CreationTime = user.CreationTime.ToLocalTime(),
                    USR_UpdateTime = user.UpdateTime.ToLocalTime(),
                    USR_LastLogonTime = user.LastLogonTime
                });
                if(user.Groups!=null){
                    foreach(string group in user.Groups){
                        objGroupUser.Add( new GRP_USR{
                            GRP_CUID = group,
                            USR_CUID = infoObject.CUID
                        });
                    }
                }
            }
            GetSecurity(ref infoObjects, ref lstPrincipales, ref lstRights, ref lstRoles);
            foreach(IDataBase db in databases){
                succeed &= db.InsertObjects(objUsers);
                succeed &= db.InsertObjects(objGroupUser);
                succeed &= db.InsertObjects(lstPrincipales);
                succeed &= db.InsertObjects(lstRights);
                succeed &= db.InsertObjects(lstRoles);
            }
            return succeed;
        }

        public bool GetFolders(){
            bool succeed = true;
            base.Log("Extract Folders from web service");
            List<FOLDER> lstFolders = new List<FOLDER>();
            List<PRINCIPALE> lstPrincipales = new List<PRINCIPALE>();
            List<PRINCIPALRIGHT> lstRights = new List<PRINCIPALRIGHT>();
            List<PRINCIPALROLE> lstRoles = new List<PRINCIPALROLE>();
            string[] select = new string[]{
                    "SI_CUID", "SI_ID", "SI_PARENT_CUID", "SI_KIND", "SI_NAME", "SI_DESCRIPTION", "SI_CREATION_TIME", "SI_UPDATE_TS",
                    "SI_PATH",
                    "SI_OWNER",
                    "SI_OWNERID"
                };
            string[] kind = new string[] { "SystemFolder", "Folder", "FavoriteFolder" };
            string[] queries = new string[]{
                "query://{SELECT " + String.Join(",", select) + " FROM CI_SYSTEMOBJECTS WHERE SI_KIND='Folder'}",
                "query://{SELECT " + String.Join(",", select) + " FROM CI_INFOOBJECTS WHERE SI_KIND='Folder'}",
                "query://{SELECT " + String.Join(",", select) + " FROM CI_INFOOBJECTS WHERE SI_KIND='FavoritesFolder'}"
            };

            for(int i=0;i<queries.Length;i++){
                List<InfoObject> infoObjects = null;
                succeed &= GetObjects(out infoObjects, queries[i], true);
                foreach(InfoObject infoObject in infoObjects){
                    FOLDER tFolder = new FOLDER{
                        FOL_ID = infoObject.ID,
                        FOL_CUID = infoObject.CUID,
                        FOL_Kind = kind[i],
                        FOL_Name = infoObject.Name,
                        FOL_Description = infoObject.Description,
                        FOL_ParentCUID = infoObject.ParentCUID,
                        FOL_CreationTime = infoObject.CreationTime.ToLocalTime(),
                        FOL_Owner = infoObject.Owner,
                        USR_CUID = infoObject.OwnerCUID
                    };
                    if(infoObject is Folder){
                        Folder folder = (Folder)infoObject;
                        tFolder.FOL_Path = ConvertPath(folder.Path);
                    }else if(infoObject is FavoritesFolder){
                        FavoritesFolder favoritesFolder = (FavoritesFolder)infoObject;
                        tFolder.FOL_Path = ConvertPath(favoritesFolder.Path);
                    }
                    lstFolders.Add(tFolder);
                }
                GetSecurity(ref infoObjects, ref lstPrincipales, ref lstRights, ref lstRoles);
            }
            foreach(IDataBase db in databases){
                succeed &= db.InsertObjects(lstFolders);
                succeed &= db.InsertObjects(lstPrincipales);
                succeed &= db.InsertObjects(lstRights);
                succeed &= db.InsertObjects(lstRoles);
            }
            return succeed;
        }

        public bool GetConnections(){
            bool succeed = true;
            base.Log("Extract Connections from web service");
            List<CONNECTION> lstConnections = new List<CONNECTION>();
            //List<DOC_CON> lstConnectionDocument = new List<DOC_CON>();
            string[] select = new string[]{
                    "SI_CUID", "SI_ID", "SI_PARENT_GUID", "SI_KIND", "SI_NAME", "SI_DESCRIPTION", "SI_CREATION_TIME", "SI_UPDATE_TS",
                    "SI_OBJ_VERSION","SI_OWNER", "SI_OWNERID"
                };
            string[] queries = new string[]{
                "query://{SELECT " + String.Join(",", select) + ",SI_CONNECTION_NETWORKLAYER,SI_CONNECTION_DATABASE FROM CI_APPOBJECTS WHERE SI_KIND='CCIS.DataConnection'}",
                "query://{SELECT " + String.Join(",", select) + ",SI_CATALOG_CAPTION,SI_PROVIDER_CAPTION,SI_CUBE_CAPTION,SI_CONNECTION_TYPE FROM CI_APPOBJECTS WHERE SI_KIND='CommonConnection'}",
                "query://{SELECT " + String.Join(",", select) + ",SI_METADATA_PROPERTIES,SI_METADATA_BVCONN_KIND FROM CI_APPOBJECTS WHERE SI_KIND='MetaData.DataConnection'}"
            };
            for(int i=0;i<queries.Length;i++){
                List<InfoObject> infoObjects = null;
                succeed &= GetObjects(out infoObjects, queries[i], true);
                foreach(InfoObject infoObject in infoObjects){
                    CONNECTION tCon = new CONNECTION{
                            CON_CUID = infoObject.CUID,
                            CON_ID = infoObject.ID,
                            CON_ParentCUID = infoObject.ParentCUID,
                            CON_Kind = infoObject.Kind,
                            CON_Name = infoObject.Name,
                            CON_Description = infoObject.Description,
                            CON_UpdateTime = infoObject.UpdateTime.ToLocalTime(),
                            CON_CreationTime = infoObject.CreationTime.ToLocalTime(),
                            CON_Owner = infoObject.Owner,
                        };
                    if(infoObject is GenericInfoObject){
                        CustomProperties custProps = ((GenericInfoObject)infoObject).CustomProperties;
                        if(custProps != null){
                            tCon.CON_ObjVerson = (int?)getGenericInfoObject(custProps, "SI_OBJ_VERSION");
                            if( infoObject.Kind == "CCIS.DataConnection"){
                                tCon.CON_NetworkLayer = (string)getGenericInfoObject(custProps, "SI_CONNECTION_NETWORKLAYER");
                                tCon.CON_Database = (string)getGenericInfoObject(custProps, "SI_CONNECTION_DATABASE");
                            }else if( infoObject.Kind == "CommonConnection"){
                                tCon.CON_Provider = (string)getGenericInfoObject(custProps, "SI_PROVIDER_CAPTION");
                                tCon.CON_Catalog = (string)getGenericInfoObject(custProps, "SI_CATALOG_CAPTION");
                                tCon.CON_Cube = (string)getGenericInfoObject(custProps, "SI_CUBE_CAPTION");
                            }else if( infoObject.Kind == "CommonConnection"){
                                tCon.CON_BVKind = (int?)getGenericInfoObject(custProps, "SI_METADATA_BVCONN_KIND");
                            }
                        }
                        /*object[] ret = (object[])getGenericInfoObject(custProps, null);
                            if(ret!=null){
                                foreach(string value in ret){
                                    lstConnectionDocument.Add(new DOC_CON{
                                        CON_CUID = infoObject.CUID,
                                        DOC_CUID = value,
                                    });
                                }
                        }*/
                    /*}else if(infoObject is MetaDataDataConnection){
                        MetaDataDataConnection mdc = ((MetaDataDataConnection)infoObject);
                        tCon.CON_ObjVerson = mdc.Versions;
                        tCon.CON_BVKind = mdc.MetaDataProperties.BusinessViewConnectionKind;
                    */}else{
                        throw new ApplicationException("Connection of kind " + infoObject.Kind + " are not supported!");
                    }
                    lstConnections.Add(tCon);
                }
            }
            foreach(IDataBase db in databases){
                succeed &= db.InsertObjects(lstConnections);
                //succeed &= db.InsertObjects(lstConnectionDocument);
            }
            return succeed;
        }

        public bool GetUniverses(){
            bool succeed = true;
            base.Log("Extract Universes from web service");
            List<UNIVERSE> lstUniverses = new List<UNIVERSE>();
            List<UNI_CON> lstUniversesConnections = new List<UNI_CON>();
            List<UNI_DOC> lstReportsUniverses = new List<UNI_DOC>();
            string[] select = new string[]{
                    "SI_CUID", "SI_ID", "SI_PARENT_GUID", "SI_KIND", "SI_NAME", "SI_DESCRIPTION", "SI_CREATION_TIME", "SI_UPDATE_TS",
                    "SI_SPECIFIC_KIND","SI_PARENT_FOLDER_CUID","SI_OBJ_VERSION","SI_OWNER","SI_OWNERID"
                };
            string[] queries = new string[]{
                "query://{SELECT " + String.Join(",", select) + ",SI_REVISIONNUM,SI_DATACONNECTION,SI_WEBI FROM CI_APPOBJECTS WHERE SI_KIND='Universe' }",
                "query://{SELECT " + String.Join(",", select) + ",SI_SL_VERSION_NUMBER,SI_SL_UNIVERSE_TO_CONNECTIONS,SI_SL_DOCUMENTS FROM CI_APPOBJECTS WHERE SI_KIND='DSL.MetaDataFile' }"
            };
            for(int i=0;i<queries.Length;i++){
                List<InfoObject> infoObjects = null;
                succeed &= GetObjects(out infoObjects, queries[i], true);
                foreach (InfoObject infoObject in infoObjects){
                    UNIVERSE uni = new UNIVERSE{
                            UNI_ID = infoObject.ID,
                            UNI_CUID = infoObject.CUID,
                            UNI_Kind = infoObject.Kind,
                            UNI_Name = infoObject.Name,
                            FOL_CUID = infoObject.ParentCUID,
                            UNI_Description = infoObject.Description,
                            UNI_CreationTime = infoObject.CreationTime.ToLocalTime(),
                            USR_CUID = infoObject.OwnerCUID,
                            UNI_UpdateTime = infoObject.UpdateTime
                        };
                    object[] connections = null;
                    object[] documents = null;

                    if(infoObject is Universe){
                        Universe universe = (Universe)infoObject;
                        uni.UNI_RevisionNumber = universe.RevisionNumber;
                        connections = universe.DataConnections;
                    }else if(infoObject is GenericInfoObject){
                        CustomProperties custProps = ((GenericInfoObject)infoObject).CustomProperties;
                        if(custProps != null){
                            uni.UNI_RevisionNumber = (int?)getGenericInfoObject(custProps, "SI_SL_VERSION_NUMBER");
                            documents = (object[])getGenericInfoObject(custProps, null, 0, 1);
                            connections = (object[])getGenericInfoObject(custProps, null, 2, 3);
                        }
                    }
                    lstUniverses.Add(uni);
                    if(connections!=null){
                        foreach(string connection in connections){
                            lstUniversesConnections.Add( new UNI_CON{
                                UNI_CUID = infoObject.CUID,
                                CON_CUID = connection
                            });
                        }
                    }
                    if(documents!=null){
                        foreach(string document in documents){
                            lstReportsUniverses.Add( new UNI_DOC{
                                UNI_CUID = infoObject.CUID,
                                DOC_CUID = document
                            });
                        }
                    }
                }
            }
            foreach(IDataBase db in databases){
                succeed &= db.InsertObjects(lstUniverses);
                succeed &= db.InsertObjects(lstUniversesConnections);
                succeed &= db.InsertObjects(lstReportsUniverses);
            }
            return succeed;
        }

        public bool GetDocuments(){
            bool succeed = true;
            List<DOCUMENT> lstReports = new List<DOCUMENT>();
            //List<UNI_DOC> lstReportsUniverses = new List<UNI_DOC>();
            //List<DOC_CON> lstReportsConnections = new List<DOC_CON>();
            List<PRINCIPALE> lstPrincipales = new List<PRINCIPALE>();
            List<PRINCIPALRIGHT> lstRights = new List<PRINCIPALRIGHT>();
            List<PRINCIPALROLE> lstRoles = new List<PRINCIPALROLE>();
            string[] select = new string[]{
                        "SI_CUID", "SI_ID", "SI_NAME", "SI_KIND", "SI_DESCRIPTION", "SI_PARENT_CUID", "SI_CREATION_TIME", "SI_UPDATE_TS",
                        "SI_PARENT_FOLDER_CUID",
                        "SI_PARENT_FOLDER",
                        "SI_AUTHOR",
                        "SI_OWNER",
                        "SI_OWNERID",
                        "SI_CHILDREN",
                        "SI_RECURRING",
                        "SI_NEXTRUNTIME",
                        "SI_RUNNABLE_OBJECT",
                        "SI_SCHEDULE_STATUS",
                        "SI_STATUSINFO",
                        "SI_LAST_RUN_TIME",
                        "SI_LAST_SUCCESSFUL_INSTANCE_ID"
                        //"SI_UNIVERSE",
                        //"SI_DSL_UNIVERSE"
                };
            select = new string[]{"*"};
            string[] kind = new string[] { "Webi", "FullClient", "CrystalReport", "ObjectPackage","Publication" };
            for(int i=0;i<kind.Length;i++){
                base.Log("Extract " + kind[i] + " documents from web service");
                //string query = "path://InfoObjects/Root Folder/**/*?OrderBy=SI_NAME DESC";
                string query = "query://{SELECT " + String.Join(",", select) + " FROM CI_INFOOBJECTS WHERE SI_KIND='" + kind[i] + "' AND SI_INSTANCE=0}";
                List<InfoObject> infoObjects = null;
                succeed &= GetObjects(out infoObjects, query, true);
                foreach(InfoObject infoObject in infoObjects){
                    /*string[] universes = null;
                    if(infoObject is Webi){
                        if((infoObject as Webi).WebiProcessingInfo != null) universes = (infoObject as Webi).WebiProcessingInfo.Universes;
                    }else if(infoObject is CrystalReport){
                        if ((infoObject as CrystalReport).PluginProcessingInterface != null) universes = (infoObject as CrystalReport).PluginProcessingInterface.UniversesInfo;
                    }else if(infoObject is FullClient){
	                    if ((infoObject as FullClient).FullClientProcessingInfo != null) universes = (infoObject as FullClient).FullClientProcessingInfo.Universes;
	                    FullClientDataProvider[] dataproviders = (infoObject as FullClient).FullClientProcessingInfo.FullClientDataProviders;
	                    if(dataproviders!=null){
	                        foreach(FullClientDataProvider dataprovider in dataproviders){
	                            lstReportsConnections.Add( new DOC_CON{
	                                DOC_CUID = infoObject.CUID,
	                                CON_CUID = dataprovider.SourceID
	                            });
	                        }
                        }
                    }else if(infoObject is Publication){
                        if ((infoObject as Publication).FullClientProcessingInfo != null) universes = (infoObject as Publication).FullClientProcessingInfo.Universes;
                    }else if(infoObject is ObjectPackage){
                    }*/
                    lstReports.Add( new DOCUMENT{
                        DOC_ID = infoObject.ID,
                        DOC_CUID = infoObject.CUID,
                        USR_CUID = infoObject.OwnerCUID,
                        DOC_Name = infoObject.Name,
                        DOC_Kind = infoObject.Kind,
                        FOL_CUID = infoObject.ParentCUID,
                        DOC_Description = infoObject.Description,
                        DOC_CreationTime = infoObject.CreationTime.ToLocalTime(),
                        DOC_UpdateTime = infoObject.UpdateTime.ToLocalTime(),
                        DOC_ChildrenObjects = infoObject.ChildrenObjects,
                       // DOC_DocSenderCUID = infoObject.,
                        DOC_ErrorMessage = infoObject.ErrorMessage,
                        DOC_UiStatus = infoObject.UiStatus,
                        DOC_LastSuccessfulInstanceCUID = infoObject.LastSuccessfulInstanceCUID
                    });
                    /*if(universes!=null){
                        foreach(string universe in universes){
                            lstReportsUniverses.Add( new UNI_DOC{
                                DOC_CUID = infoObject.CUID,
                                UNI_CUID = universe
                            });
                        }
                    }*/
                }
                GetSecurity(ref infoObjects, ref lstPrincipales, ref lstRights, ref lstRoles);
            }
            foreach(IDataBase db in databases){
                succeed &= db.InsertObjects(lstReports);
                succeed &= db.InsertObjects(lstPrincipales);
                succeed &= db.InsertObjects(lstRights);
                succeed &= db.InsertObjects(lstRoles);
                //succeed &= db.InsertObjects(lstReportsUniverses);
                //succeed &= db.InsertObjects(lstReportsConnections);
            }
            return succeed;
        }

        public bool GetInstances(){
            bool succeed = true;
            List<INSTANCE> lstInstances = new List<INSTANCE>();
            List<SCHEDULEFOR> lstScheduleFor = new List<SCHEDULEFOR>();
            string[] select = new string[]{
                        "SI_ID", "SI_CUID", "SI_NAME", "SI_KIND", "SI_DESCRIPTION","SI_CREATION_TIME","SI_UPDATE_TS",
                        "SI_PARENT_CUID",
                        "SI_PARENT_FOLDER_CUID",
                        "SI_PARENT_FOLDER",
                        "SI_OWNER",
                        "SI_OWNERID",
                        "SI_STARTTIME",
                        "SI_ENDTIME",
                        //"SI_UNIVERSE",
                        "SI_RECURRING",
                        "SI_NEXTRUNTIME",
                        "SI_RUNNABLE_OBJECT",
                        "SI_SCHEDULE_STATUS",
                        "SI_STATUSINFO",
                        "SI_LAST_SUCCESSFUL_INSTANCE_ID",
                        "SI_SCHEDULEINFO",
                        "SI_SCHEDULEINFO.SI_UISTATUS",
                        "SI_SCHEDULEINFO.SI_OUTCOME",
                        "SI_SCHEDULEINFO.SI_MULTIPASS"
                };
            string[] kind = new string[] { "Pdf","Excel","Webi","CrystalReport","Powerpoint","Word","Publication","ObjectPackage" }; //'Txt'
            for(int i=0;i<kind.Length;i++){
                base.Log("Extract " + kind[i] + " instances from web service"); //+ String.Join(",", kind));
                string query = "query://{SELECT " + String.Join(",", select) + " FROM CI_INFOOBJECTS WHERE SI_KIND='" + kind[i] + "' AND SI_INSTANCE!=0}";
                List<InfoObject> infoObjects = null;
                succeed &= GetObjects(out infoObjects, query, true);
                foreach(InfoObject infoObject in infoObjects){
                    INSTANCE tInstance = new INSTANCE{
                        INS_ID = infoObject.ID,
                        INS_CUID = infoObject.CUID,
                        INS_Name = infoObject.Name,
                        INS_Kind = infoObject.Kind,
                        INS_ParentCUID = infoObject.ParentCUID,
                        INS_Description = infoObject.Description,
                        USR_CUID = infoObject.OwnerCUID,
                        INS_CreationTime = infoObject.CreationTime.ToLocalTime(),
                        INS_UpdateTime = infoObject.UpdateTime.ToLocalTime(),
                        INS_IsRecurring = infoObject.IsRecurring,
                       // INS_DocSenderCUID = infoObject.DocSenderCUID,
                        INS_ErrorMessage = infoObject.ErrorMessage,
                        INS_NextRunTime = infoObject.NextRunTime.ToLocalTime(),
                        INS_StartTime = infoObject.StartTime.ToLocalTime(),
                        INS_UiStatus = infoObject.UiStatus
                    };
                    SchedulingInfo schedulingInfo = null;
                    switch (infoObject.Kind){
                        case "Webi": schedulingInfo = ((Webi)infoObject).SchedulingInfo; break;
                        case "CrystalReport": schedulingInfo = ((CrystalReport)infoObject).SchedulingInfo; break;
                        case "Publication": schedulingInfo = ((Publication)infoObject).SchedulingInfo; break;
                        case "ObjectPackage": schedulingInfo = ((ObjectPackage)infoObject).SchedulingInfo; break;
                        case "Pdf": schedulingInfo = ((Pdf)infoObject).SchedulingInfo; break;
                        case "Excel": schedulingInfo = ((Excel)infoObject).SchedulingInfo; break;
                        case "Powerpoint": schedulingInfo = ((Powerpoint)infoObject).SchedulingInfo; break;
                        case "Word": schedulingInfo = ((Word)infoObject).SchedulingInfo; break;
                        //case "FullClient": schedulingInfo = ((FullClient)infoObject).SchedulingInfo; break;
                        default: throw new Exception(infoObject.Kind + " object is not supported !");
                    }
                    if (schedulingInfo != null) {
                        tInstance.SCI_BeginDate = schedulingInfo.BeginDate.ToLocalTime();
                        tInstance.SCI_EndDate = schedulingInfo.EndDate.ToLocalTime();
                        tInstance.SCI_RightNow = schedulingInfo.RightNow;
                        tInstance.SCI_Cleanup = schedulingInfo.Cleanup;
                        tInstance.SCI_ScheduleType = schedulingInfo.ScheduleType.ToString();
                        tInstance.SCI_RetriesAttempted = schedulingInfo.RetriesAttempted;
                        tInstance.SCI_Outcome = schedulingInfo.Outcome.ToString();
                        tInstance.SCI_Status = schedulingInfo.Status.ToString();
                        tInstance.SCI_SubmitterID = schedulingInfo.SubmitterID;
                        tInstance.SCI_RetriesAllowed = schedulingInfo.RetriesAllowed;
                        tInstance.SCI_RetryInterval = schedulingInfo.RetryInterval;
                        tInstance.SCI_ErrorMessage = schedulingInfo.ErrorMessage;
                        if(schedulingInfo.Destinations!=null){
                            foreach( Destination dst in schedulingInfo.Destinations){
                                if (tInstance.SCI_Destinations != null) tInstance.SCI_Destinations += ",";
                                if (dst.DestinationScheduleOptions is DiskUnmanagedScheduleOptions){
                                    tInstance.SCI_Destinations += "DiskUnmanaged";
                                }else if(dst.DestinationScheduleOptions is ManagedScheduleOptions){
                                    tInstance.SCI_Destinations += "Managed";
                                }else if(dst.DestinationScheduleOptions is FtpScheduleOptions){
                                    tInstance.SCI_Destinations += "Ftp";
                                }else if(dst.DestinationScheduleOptions is SMTPScheduleOptions){
                                    tInstance.SCI_Destinations += "SMTP";
                                }
                            }
                        }
                        if(schedulingInfo.MultiPass!=null){
                            foreach( String multipass in schedulingInfo.MultiPass){
                                lstScheduleFor.Add( new SCHEDULEFOR{
                                    INS_CUID = infoObject.CUID,
                                    USR_CUID = multipass
                                });
                            }
                        }
                    }
                    lstInstances.Add(tInstance);
                }
            }
            foreach(IDataBase db in databases){
                succeed &= db.InsertObjects(lstInstances);
                succeed &= db.InsertObjects(lstScheduleFor);
            }
            return succeed;
        }

        public bool GetCategories(){
            bool succeed = true;
            base.Log("Extract Categories from web service");
            List<CATEGORY> lstCategories = new List<CATEGORY>();
            List<CAT_DOC> lstCategoryDocument = new List<CAT_DOC>();
            string[] select = new string[]{
                    "SI_ID", "SI_KIND", "SI_NAME", "SI_PARENT_CUID", "SI_OWNER", "SI_OWNERID", "SI_DESCRIPTION", "SI_CREATION_TIME", "SI_UPDATE_TS",
                    "SI_PATH",
                    "SI_DOCUMENTS"
                };
            List<InfoObject> infoObjects = null;
            succeed &= GetObjects(out infoObjects, "query://{SELECT " + String.Join(",", select) + " FROM CI_INFOOBJECTS WHERE SI_KIND IN('Category','PersonalCategory')}");
            string[] documents=null;
            foreach(InfoObject infoObject in infoObjects){
                CATEGORY tCategory = new CATEGORY{
                    CAT_ID = infoObject.ID,
                    CAT_CUID = infoObject.CUID,
                    CAT_Name = infoObject.Name,
                    CAT_Description = infoObject.Description,
                    CAT_CreationTime = infoObject.CreationTime.ToLocalTime(),
                    CAT_ParentCUID = infoObject.ParentCUID,
                    CAT_Owner = infoObject.Owner,
                    USR_CUID = infoObject.OwnerCUID,
                    CAT_Kind = infoObject.Kind
                };
                if(infoObject is Category){
                    Category category = (Category)infoObject;
                    tCategory.CAT_Path = ConvertPath(category.Path);
                    documents = category.Documents;
                }else if(infoObject is PersonalCategory){
                    PersonalCategory personalCategory = (PersonalCategory)infoObject;
                    tCategory.CAT_Path = ConvertPath(personalCategory.Path);
                    documents = personalCategory.Documents;
                }
                if(documents!=null){
                    tCategory.CAT_Instances = documents.Length;
                    foreach(string document in documents){
                        lstCategoryDocument.Add( new CAT_DOC{
                            CAT_CUID = infoObject.CUID,
                            DOC_CUID = document
                        });
                    }
                }
                lstCategories.Add( tCategory );
            }
            foreach(IDataBase db in databases){
                succeed &= db.InsertObjects(lstCategories);
                succeed &= db.InsertObjects(lstCategoryDocument);
            }
            return succeed;
        }

        public void GetSecurity(ref List<InfoObject> lstObjects, ref List<PRINCIPALE> lstPrincipales, ref List<PRINCIPALRIGHT> lstRights, ref List<PRINCIPALROLE> lstRoles){
            foreach(InfoObject infoObject in lstObjects){
                if (infoObject.SecurityInfo2 != null && infoObject.SecurityInfo2.Principal!=null){
                    foreach(Principal principal in infoObject.SecurityInfo2.Principal){
                        lstPrincipales.Add( new PRINCIPALE{
                            PRI_CUID = principal.PrincipalCUID != null ? principal.PrincipalCUID : "null-" + infoObject.CUID,
                            PRI_ObjectCUID = infoObject.CUID,
                            PRI_ObjectKind = infoObject.Kind,
                            PRI_Role = principal.Role.ToString(),
                            PRI_IsAdvancedInheritFolders = principal.IsAdvancedInheritFolders,
                            PRI_IsAdvancedInheritGroups = principal.IsAdvancedInheritGroups,
                        });
                        if(principal.Roles!=null){
                            foreach(Role role in principal.Roles){
                                lstRoles.Add( new PRINCIPALROLE{
                                    PRI_CUID = principal.PrincipalCUID,
                                    PRI_ObjectCUID = infoObject.CUID,
                                    PRI_ObjectKind = infoObject.Kind,
                                    ROL_CUID = role.ID
                                });
                            }
                        }
                        if(principal.Rights!=null){
                            foreach(Right right in principal.Rights){
                                lstRights.Add( new PRINCIPALRIGHT {
                                    PRT_ID = ++rightId,
                                    PRI_CUID = principal.PrincipalCUID,
                                    PRT_ObjectCUID = infoObject.CUID,
                                    PRI_ObjectKind = infoObject.Kind,
                                    PRT_Right = right.ID,
                                    PRT_ApplicableKind = right.ApplicableKind,
                                    PRT_Denied = right.Denied,
                                    PRT_ObjectKind = right.ObjectKind,
                                    PRT_Owner = right.Owner,
                                    PRT_Scope = right.Scope
                                });
                            }
                        }
                    }
                }
            }
        }

        private bool GetObjects(out List<InfoObject> lstObjects, string query, bool includeSecurity=false ){
            string ciud="";
            lstObjects = new List<InfoObject>();
            try{
                GetOptions opt = new GetOptions { IncludeSecurity = includeSecurity, IncludeSecuritySpecified = includeSecurity, PageSize = 99999, PageSizeSpecified = true };
                ResponseHolder boResponse = this.boBIPlatform.Get(query, opt);
                if( boResponse!=null && boResponse.InfoObjects!=null && boResponse.InfoObjects.InfoObject!=null && boResponse.InfoObjects.InfoObject.Length != 0){
                    PagingDetails pagingDetails = boResponse.PagingDetails;
                    PageInfo[] pageInfos = pagingDetails.PageInfo;
                    int nbPages = pageInfos.Length;
                    for (int p=0; p < nbPages; p++){
                        InfoObjects boInfoObjects = null;
                        if(p==0){
                            boInfoObjects = boResponse.InfoObjects;
                        }else{
                            boInfoObjects = this.boBIPlatform.Get(pageInfos[p].PageURI, opt).InfoObjects;
                        }
                        #if DEBUG
                        System.Xml.Serialization.XmlSerializer writer = null;
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\tmp\bo-" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".xml", false, System.Text.Encoding.UTF8)){
                             writer = new System.Xml.Serialization.XmlSerializer(typeof(InfoObjects));
                             writer.Serialize(file, boInfoObjects);
                             //file.Write(boInfoObjects.objectsXML);
                        }
                        #endif
                        if (boInfoObjects.InfoObject.Length!=0){
                            if(boInfoObjects.InfoObject[0].CUID == ciud){
                                throw new Exception("Web service paging failed !");
                            }
                            ciud = boInfoObjects.InfoObject[0].CUID;
                        }
                        foreach(InfoObject obj in boInfoObjects.InfoObject){
                            lstObjects.Add(obj);
                        }
                    }
                }
                return true;
            }catch(Exception ex){
                base.Log("Failed to execute web service query - " + ex.Message + " - Query: " + query);
                return false;
            }
        }

        private string ConvertPath(Path path){
            string lFolder = null;
            if (path.PathFolder == null) return null;
            foreach (PathFolder f in path.PathFolder){
                if(lFolder!=null) lFolder = "/" + lFolder;
                lFolder = f.Name + lFolder;
            }
            return lFolder;
        }

        public object getGenericInfoObject(CustomProperties customProperties, string nameID, int startPos=0, int endPos=0){
            int nbItem = customProperties.Items.Length;
            endPos = ( endPos != 0 &&  endPos<nbItem ) ? endPos : nbItem - 1 ;
            for(int i=startPos; i<=endPos; i++ ){
                object item = customProperties.Items[i];
                if(nameID==null && item is CustomRelation ){
                    return ((CustomRelation)item).Items;
                }else if(item is CustomPropertiesDouble){
                    if (((CustomPropertiesDouble)item).nameID == nameID) return ((CustomPropertiesDouble)item).Value;
                }else if(item is CustomPropertiesString){
                    if (((CustomPropertiesString)item).nameID == nameID) return ((CustomPropertiesString)item).Value;
                }else if(item is CustomProperties){
                    if (((CustomProperties)item).nameID == nameID) return ((CustomProperties)item).Items;
                }else if(item is CustomPropertiesBool){
                    if (((CustomPropertiesBool)item).nameID == nameID) return ((CustomPropertiesBool)item).Value;
                }else if(item is CustomPropertiesDate){
                    if (((CustomPropertiesDate)item).nameID == nameID) return ((CustomPropertiesDate)item).Value;
                }else if(item is CustomPropertiesInteger){
                    if (((CustomPropertiesInteger)item).nameID == nameID) return ((CustomPropertiesInteger)item).Value;
                }
                startPos++;
            }
            return null;
        }

        public void testPaging(){

            GetOptions reportOptions = new GetOptions { PageSize = 50, PageSizeSpecified = true };
            ResponseHolder reportRH = this.boBIPlatform.Get("path://InfoObjects/**/*", null);
            if(reportRH.InfoObjects == null || reportRH.PagingDetails.PageInfo == null) return;
            string firstReportCuid="";
            for(int i=0; i < reportRH.PagingDetails.PageInfo.Length; i++){
                ResponseHolder pageRH = this.boBIPlatform.Get(reportRH.PagingDetails.PageInfo[i].PageURI, null);
                InfoObjects pageReports = pageRH.InfoObjects;
	            if (pageReports.InfoObject.Length!=0){
		            if(pageReports.InfoObject[0].CUID == firstReportCuid){
			            throw new Exception("Paging failed !");
		            }
		            firstReportCuid = pageReports.InfoObject[0].CUID;
	            }
            }

        }

    }
}
