using MFiles.VAF.Common;
using MFilesAPI;
using System;
using System.Runtime.InteropServices;

namespace Acme.Corporation.Storata.Chai.Nge
{
    public partial class VaultApplication
    {
        private string SignQuotesTitle(ObjVerEx objVerEx)
        {
            if (false == this.Configuration.SubjectTxtProperty.IsResolved)
            {
                throw new NotFoundException();
            }
            return $"{objVerEx.GetPropertyText(MFBuiltInPropertyDef.MFBuiltInPropertyDefClass)} - {objVerEx.GetPropertyText(Configuration.SubjectTxtProperty)}";
        }

        private bool isOfClass(ObjVerEx objverEx, string className)
        {
            if (objverEx == null || className.Equals(string.Empty))
            { 
                return false;
            }

            return objverEx.GetPropertyText(MFBuiltInPropertyDef.MFBuiltInPropertyDefClass).ToLower().Equals(className);

        }

        private bool SanityCheckForPersonProperties(ObjVerEx objverEx)
        {
            try
            {
                if (false == isOfClass(objverEx, Configuration.PERSON_CLASS_NAME))
                { return false; }


                if (false == this.Configuration.ContractManagersUserGroup.IsResolved)
                { return false; }

                if (false == this.Configuration.ExecutiveManagersUserGroup.IsResolved)
                { return false; }

                if (false == this.Configuration.ContractManagerRoleVLItem.IsResolved)
                { return false; }

                if (false == this.Configuration.ExecutiveManagementRoleVLItem.IsResolved)
                { return false; }

                if (false == this.Configuration.RolesSelectMProperty.IsResolved)
                { return false; }

                if(false == this.Configuration.MfilesUser.IsResolved)
                { return false; }

            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }





        private void AddMemberToGroup(Vault vault, Lookups toAdd, int mfiles_User)
        {
            try
            {
                foreach (Lookup roleAslookup in toAdd)
                {
                    if (roleAslookup.ItemGUID.Equals(Configuration.ContractManagerRoleVLItem.Guid))
                    {
                        vault.UserOperationsEx.AddMemberToUserGroup(Configuration.ContractManagersUserGroup, mfiles_User);
                        //add to Contract Manager User Group
                    }
                    if (roleAslookup.ItemGUID.Equals(Configuration.ExecutiveManagementRoleVLItem.Guid))
                    {
                        //add to Executive Manager User Group

                        vault.UserOperationsEx.AddMemberToUserGroup(Configuration.ExecutiveManagersUserGroup, mfiles_User);
                    }
                }
            }
            catch(Exception ex)
            {
                
            }
        }
        private void RemoveMemberFromGroup(Vault vault, int mfiles_User)
        {
            try
            {
                //completely remove the User from all Group. Faster, easier and less buggy than trying to generated delete and add list
                        vault.UserOperationsEx.RemoveMemberFromUserGroup(Configuration.ContractManagersUserGroup, mfiles_User);
                        vault.UserOperationsEx.RemoveMemberFromUserGroup(Configuration.ExecutiveManagersUserGroup, mfiles_User);
                                   
            }
            catch (Exception ex)
            {

            }
        }

        private void ResetGroupMembershipAddBasedOnRole(Vault vault, ObjVerEx objVerEx)
        {

            var mfiles_User = objVerEx.GetLookupID(Configuration.MfilesUser);
            var listOfRoles = objVerEx.GetLookups(Configuration.RolesSelectMProperty);


            if (mfiles_User != -1)
            {
                //reset to blank
                RemoveMemberFromGroup(vault, mfiles_User);
                //add to group based on current role list
                AddMemberToGroup(vault, listOfRoles, mfiles_User);
            }
        }



        //To Remove No longer required

        private (Lookups listToAdd, Lookups listToRemove) ListOfChanges(PropertyValueChange propertyValueChange)
        {
            Lookups listToAdd = new Lookups();
            Lookups listToRemove = new Lookups();

            var oldvalue = propertyValueChange.OldValue.Value.GetValueAsLookups();
            var newvalue = propertyValueChange.NewValue.Value.GetValueAsLookups();
            listToAdd = DifferenceOfList(oldvalue, newvalue);
            listToRemove = DifferenceOfList(newvalue, oldvalue);


            return (listToAdd, listToRemove);
        }



        private Lookups DifferenceOfList(Lookups oldList, Lookups newList)
        {
            Lookups resultingLookups = new Lookups();

            try

            {
                if (oldList == null && newList != null)
                {
                    //old list is empty the new list is the full list of changes
                    return newList;

                }

                if (oldList.IsEqual(newList, EqualityCompareOptions.LookupsIgnoreOrder)) // roles are valuelist no versioning to account for
                {
                    //if both list are the same including being null there is no change                    
                    return resultingLookups;
                }

                if (false == oldList.Intersects(newList))
                {
                    //the old list and the new are completely different the new list
                    return newList;

                }

                //mixed case, some items in both list 
                foreach (Lookup newItem in newList)
                {
                    try
                    {

                        oldList.GetLookupByItem(newItem.Item);

                    }
                    catch (ExternalException comException)
                    {
                        if (comException.ErrorCode == -2147221503)
                        {
                            //item not in the old version, therefore of interest for us

                            resultingLookups.Add(-1, newItem);


                        }

                    }
                }


            }
            catch (Exception ex)
            {


            }
            return resultingLookups;
        }


    }
}
