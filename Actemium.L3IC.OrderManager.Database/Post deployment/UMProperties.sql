USE L3IntroMES
GO

INSERT INTO [UM].[Properties]
           ([Id]
           ,[Name]
           ,[DefaultValue]
           ,[Type]
           ,[DataType])
     VALUES
            (100
           ,'UserPrefferedLanguage'
           ,''
           ,1 /*User*/
           ,2 /*Integer*/)

           ,(101
           ,'UserMenuBarDefaultExpanded'
           ,1
           ,1 /*User*/
           ,9 /*Boolean*/)

           ,(200
           ,'ComputerDefaultNavigationItem'
           ,''
           ,2 /*Computer*/
           ,2 /*Integer*/)
					 
		   ,(201
           ,'ComputerDefaultUser'
           ,''
           ,2 /*Computer*/
           ,1 /*String*/)

		   ,(202
           ,'ComputerAutoLogoutTime'
           ,''
           ,2 /*Computer*/
           ,2 /*Integer*/)

		   ,(203
           ,'ComputerTimeFormat'
           ,'dd-MM-yyyy HH:mm:ss'
           ,2 /*Computer*/
           ,1 /*String*/)

           ,(204
           ,'ComputerPathToServerRoot'
           ,''
           ,2 /*Computer*/
           ,1 /*String*/)
          
           ,(205
           ,'ComputerPathToServerRoot'
           ,''
           ,2 /*Computer*/
           ,1 /*String*/)

           ,(206
           ,'ComputerLogFileLocation'
           ,''
           ,2 /*Computer*/
           ,1 /*String*/)

           ,(207
           ,'ComputerMenuBarDefaultExpanded'
           ,1
           ,2 /*Computer*/
           ,9 /*Boolean*/)

           ,(208
           ,'ComputerMaxDetachedForms'
           ,1
           ,2 /*Computer*/
           ,2 /*Integer*/)
GO


