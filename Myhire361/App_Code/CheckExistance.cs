using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;

public class CheckExistance
{
    string columnName, Value;
    Boolean isExists;

    public Boolean ExistanceForInsert(DataTable dt, Hashtable hsTable)
    {
        //------------ This is used during insertion ----------------------  ---------

      for (int idx = 0; idx < dt.Rows.Count; idx++)
       {
           foreach (DictionaryEntry kvp in hsTable)
            {
                    columnName = kvp.Key.ToString();
                    Value = kvp.Value.ToString().ToUpper();

                    if ((dt.Rows[idx][columnName].ToString().ToUpper()).Equals(Value))
                    {
                        isExists = true;
                        return isExists;
                    }
            }
        }
        return isExists;
    }
    public Boolean ExistanceForUpdate(DataTable dt, Hashtable hsTable, string PrimaryKey, int PrimaryKeyValue)
    {
        //------------ This is used during insertion -------------------------------
      

            for (int idx = 0; idx < dt.Rows.Count; idx++)
            {
                foreach (DictionaryEntry kvp in hsTable)
                {
                    columnName = kvp.Key.ToString();
                    Value = kvp.Value.ToString().ToUpper();

                    if ((dt.Rows[idx][columnName].ToString().ToUpper()).Equals(Value))
                    {
                        if (Convert.ToInt32(dt.Rows[idx][PrimaryKey].ToString())!=PrimaryKeyValue)
                        {
                            isExists = true;
                            return isExists;
                        }
                    }
                }
            }        
      
        return isExists;
    }
    public CheckExistance()
	{
		
	}
}