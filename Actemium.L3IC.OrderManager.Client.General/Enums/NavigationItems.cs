namespace Actemium.L3IC.OrderManager.Client.General.Enums {
    public enum NavigationItems {
        // Not pages, but seperate handling (negative)
        Error = -999,
        Null = -998,
        Help = -100,

        NoSelection = -1,

        //Template
        EmptyForm = 0000,

        // BASE
        Logon = 1,
        Home = 2,
        Previous = 3,
        Next = 4,
        Test = 5,
        NewProjectForm = 6,
        UserProfile = 7,

        // MasterData (10xx)
        MasterData = 101,

        // Orders (20xx)
        ActualOrders = 201,
        FinishedOrders = 202,

        // General Configuration and User management (90xx)
        Diagnostics = 9000,
        ApplicationSettings = 9001,
        HistoryKeyManagement = 9002,
        UserManagement = 9011,
        GroupManagement = 9012,
        ComputerManagement = 9013,
        Translations = 9020,
        DataIntegrationMessages = 9030,
        TestForm = 9099,

        // ADVANCED_ACTEMIUM
        ActemiumTest = 99999,
    }

}
