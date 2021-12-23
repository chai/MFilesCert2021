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

        public void CheckForName(EventHandlerEnvironment env)
        {
            string PersonClassName= "Person";
            //Applied only to Person class, normally would apply via Attribute 
            //e.g.         [EventHandler(MFEventHandlerType.MFEventHandlerAfterCheckInChangesFinalize, ObjectType = "F.OT.Person", Class = "Class Alias")]
            //but as we're not changing anything in the vault, including adding alia
            //we're setting up a manual check

            if (env.ObjVerEx.GetPropertyText(MFBuiltInPropertyDef.MFBuiltInPropertyDefClass).Equals(PersonClassName))
            {


                if (false == this.Configuration.ContractManagersUserGroup.IsResolved)
                { return; }

                if (false == this.Configuration.ExecutiveManagersUserGroup.IsResolved)
                { return; }

                if (false == this.Configuration.ContractManagerRoleVLItem.IsResolved)
                { return; }

                if (false == this.Configuration.ExecutiveManagementRoleVLItem.IsResolved)
                { return; }

                if (false == this.Configuration.RolesSelectMProperty.IsResolved)
                { return; }

                // var RoleList = env.ObjVerEx.GetAllDirectReferences(this.Configuration.SelectMPropertyRoles);

                //// Load document (type 0) with ID 1 and version 16 from the vault.
                //var objVerEx = new ObjVerEx(vault,
                //    (int)MFBuiltInObjectType.MFBuiltInObjectTypeDocument,
                //    id: 1,
                //    version: 16
                //);

                // Compare the version loaded above (16) with its previous version (probably 15).
                var roleChange = new ObjVerChanges(env.ObjVerEx).Changed.FirstOrDefault(p => p.PropertyDef == this.Configuration.RolesSelectMProperty);
                if (roleChange !=null)
                {
                    switch (roleChange.ChangeType)
                    {
                        case PropertyValueChangeType.Added:
                            // Handle additions.
                            break;
                        case PropertyValueChangeType.Modified:
                            // Handle modified values.
                            break;
                        case PropertyValueChangeType.Removed:
                            // Handle removed values.
                            break;
                    }

                }

              //  var roleChange = objVerChanges.FirstOrDefault(p => p.PropertyDef == this.Configuration.RolesSelectMProperty);

            }
        }
    }
}
