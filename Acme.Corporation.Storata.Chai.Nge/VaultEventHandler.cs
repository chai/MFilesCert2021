using MFiles.VAF.Common;
using MFilesAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Corporation.Storata.Chai.Nge
{
    public partial class VaultApplication
    {
        [EventHandler(MFEventHandlerType.MFEventHandlerAfterCheckInChangesFinalize, ObjectType = "MF.OT.Person")]

        public void CheckForRoles(EventHandlerEnvironment env)
        {

            //Applied only to Person class, normally would apply via Attribute 
            //e.g.         [EventHandler(MFEventHandlerType.MFEventHandlerAfterCheckInChangesFinalize, ObjectType = "F.OT.Person", Class = "Class Alias")]
            //but as we're not changing anything in the vault, including adding alia
            //we're setting up a manual check
            try
            {
                if (SanityCheckForPersonProperties(env.ObjVerEx))
                {
                    // var RoleList = env.ObjVerEx.GetAllDirectReferences(this.Configuration.SelectMPropertyRoles);
                 //   var aaroleChange = new ObjVerChanges(env.ObjVerEx).Changed;
                    var roleChange = new ObjVerChanges(env.ObjVerEx).Changed.FirstOrDefault(p => p.PropertyDef == this.Configuration.RolesSelectMProperty);


                    if (roleChange == null)
                    { return; }

                    //Sanity check above. Can start the business logic

                    //  var listOfChanges= ListOfChanges(roleChange);

                    ResetGroupMembershipAddBasedOnRole(env.Vault, env.ObjVerEx);

                }

                //  var roleChange = objVerChanges.FirstOrDefault(p => p.PropertyDef == this.Configuration.RolesSelectMProperty);


            }
            catch (Exception ex)
            {

            }
        }

        [EventHandler(MFEventHandlerType.MFEventHandlerAfterDeleteObject, ObjectType = "MF.OT.Person")]
        [EventHandler(MFEventHandlerType.MFEventHandlerAfterDestroyObject, ObjectType = "MF.OT.Person")]

        public void RemoveFromRoles(EventHandlerEnvironment env)
        {

            //Applied only to Person class, normally would apply via Attribute 
            //e.g.         [EventHandler(MFEventHandlerType.MFEventHandlerAfterCheckInChangesFinalize, ObjectType = "F.OT.Person", Class = "Class Alias")]
            //but as we're not changing anything in the vault, including adding alias
            //we're setting up a manual check

            try
            {
                if (SanityCheckForPersonProperties(env.ObjVerEx))
                {
                    var mfiles_User = env.ObjVerEx.GetLookupID(Configuration.MfilesUser);
                    //var listOfRoles = env.ObjVerEx.GetLookups(Configuration.RolesSelectMProperty);

                    if (mfiles_User != -1 ) 
                    {
                        RemoveMemberFromGroup(env.Vault, mfiles_User);
                    }
                    //sanity check above 
                    //if a person is deleted or destroy check for and remove them from all list to clean up.

                }
            }
            catch (Exception ex)
            {

            }
        }

        [EventHandler(MFEventHandlerType.MFEventHandlerAfterUndeleteObjectFinalize, ObjectType = "MF.OT.Person")]
        public void AddBackToRoles(EventHandlerEnvironment env)
        {

            //Applied only to Person class, normally would apply via Attribute 
            //e.g.         [EventHandler(MFEventHandlerType.MFEventHandlerAfterCheckInChangesFinalize, ObjectType = "F.OT.Person", Class = "Class Alias")]
            //but as we're not changing anything in the vault, including adding alias
            //we're setting up a manual check

            try
            {
                if (SanityCheckForPersonProperties(env.ObjVerEx))
                {
                    var mfiles_User = env.ObjVerEx.GetLookupID(Configuration.MfilesUser);


                    if (mfiles_User != -1)
                    {
                        ResetGroupMembershipAddBasedOnRole(env.Vault, env.ObjVerEx);
                    }
                    //sanity check above 
                    //if a person is deleted or destroy check for and remove them from all list to clean up.

                }
            }
            catch (Exception ex)
            {

            }
        }


    }
}
