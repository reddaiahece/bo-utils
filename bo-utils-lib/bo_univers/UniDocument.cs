extern alias DSWS115;

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using DSWS115::BusinessObjects.DataSource;
using DSWS115::BusinessObjects.DSWS.BIPlatform.Desktop;
using DSWS115::BusinessObjects.DSWS.Session;
using Connection = DSWS115::BusinessObjects.DSWS.Connection;
using Session_ = DSWS115::BusinessObjects.DSWS.Session.Session;
using DSWS115::BusinessObjects.DSWS.QueryService;
//using DataSourceClass = DSWS115::BusinessObjects.DataSource.DataSourceClass;

namespace BusinessObjectsUtils.Univers
{
    public class MyObject {
        public string Description{ get; set;}
        public string Key{ get; set;}
        public string Name{ get; set;}
        public string Path{ get; set;}
        public bool HasLov{ get; set;}
        public string Type{ get; set;}
    }


    public class UniDocument
    {

        public UniDocument()
        {
            Connection boConnection = new Connection(@"http://watchmen:8080/dswsbobje/services/session");
            EnterpriseCredential boCredential = new EnterpriseCredential();
            boCredential.Domain = "watchmen";
            boCredential.AuthType = "secEnterprise";
            boCredential.Login = "Administrator";
            boCredential.Password = "";
            Session_ boSession = new Session_(boConnection);
            SessionInfo boSI = boSession.Login(boCredential);

            string[] strBOQuerySrvURL = boSession.GetAssociatedServicesURL("QueryService");
            if (strBOQuerySrvURL.Length == 0) throw new Exception("QueryService not found");
            QueryService boQuerySrv = QueryService.GetInstance(boSession,strBOQuerySrvURL[0]);

            DataSource[] boUniverses = boQuerySrv.GetDataSourceList();
            String boUniverseUID = boUniverses[0].UID;
            DataSourceSpecification boUniverseSpecification = boQuerySrv.GetDataSource(boUniverseUID);


            DataSourceClass[] boDataSourceClasses = boUniverseSpecification.DataSourceClass;
            Hierarchy[] boHierarchy = boUniverseSpecification.Hierarchy;
            ArrayList detailKeyList = new ArrayList();
            ArrayList dimensionKeyList = new ArrayList();
            ArrayList measureKeyList = new ArrayList();
            ArrayList preConditionObjectKeyList = new ArrayList();

            for (int i=0; i<boDataSourceClasses.Length; i++){
                DataSourceObject[] boDataSourceObjects = boDataSourceClasses[i].DataSourceObject;
                for (int j=0; j<boDataSourceObjects.Length; j++){
                    if (boDataSourceObjects[j] is Detail){
                        detailKeyList.Add(boDataSourceObjects[j].Key);
                    }if (boDataSourceObjects[j] is Dimension){
                        dimensionKeyList.Add(boDataSourceObjects[j].Key);
                    }if (boDataSourceObjects[j] is Measure){
                        measureKeyList.Add(boDataSourceObjects[j].Key);
                    }if (boDataSourceObjects[j] is PreConditionObject){
                        preConditionObjectKeyList.Add(boDataSourceObjects[j].Key);
                    }
                }
            }

            ArrayList scopeKeyList = new ArrayList();
            for (int k=0; k<boHierarchy.Length; k++){
                DataSourceObject[] boScopeObjects = boHierarchy[k].DataSourceObject;
                for (int m=0; m<boScopeObjects.Length; m++){
                    scopeKeyList.Add(boScopeObjects[m].Key);
                }
            }

            Object[] dimensionKeys = dimensionKeyList.ToArray();
            Object[] detailKeys = detailKeyList.ToArray();
            Object[] measureKeys = measureKeyList.ToArray();
            Object[] preConditionObjectKeys = preConditionObjectKeyList.ToArray();
            Object[] scopeKeys = scopeKeyList.ToArray();

            boSession.Logout();
        }

        private void GetObjects(DataSourceClass pClass ){


        }


    }
}
