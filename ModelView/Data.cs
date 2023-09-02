using DataModel;
using Microsoft.Identity.Client;

namespace ModelView;

public class Data
{
    private DataManager dm;
    #region singleton
    private static Data instance;
    private Data()
    {
        dm = DataManager.Get(DataProvidersList.SqlServer);
    }
    public static Data Get()
    {
        if (instance == null) instance = new Data();
        return instance;
    }
#endregion
}