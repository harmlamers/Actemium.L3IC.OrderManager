INSERT INTO [AS].[ApplicationSettingsCategories]
           ([ApplicationSettingsCategoryId]
           ,[Name]
           ,[Description])
     VALUES
           (0
           ,'Actemium'
           ,'Actemium settings')

					 ,(1000
           ,'General'
           ,'General settings')

           ,(2000
           ,'Languages'
           ,'Languages')

           ,(3000
           ,'UserManagement'
           ,'UserManagement settings')

GO

INSERT INTO [AS].[ApplicationSettings]
           ([ApplicationSettingId]
           ,[ApplicationSettingsCategoryId]
           ,[Name]
           ,[Description]
           ,[DataTypeId]
           ,[Value]
           ,[ListId])
     VALUES
           (1000
           ,1000
           ,'HelpLocation'
           ,'Location of the help file relative to the server root'
           ,1
           ,''
           ,NULL)

           ,(1001
           ,1000
           ,'ValidClientVersion'
           ,'Minimum version of the client that is allowed to run'
           ,1
           ,'0.0'
           ,NULL)

           ,(1002
           ,1000
           ,'NameAbbreviationStyle'
           ,'Name abbreviation style'
           ,2
           ,'0'
           ,NULL)

           ,(1
           ,0
           ,'ActemiumCanUseOldClientVersion'
           ,'Can Actemium use an old version of the client'
           ,9
           ,'True'
           ,NULL)

           ,(10
           ,0
           ,'DataType_String_Editor'
           ,'Editor for Datatype String'
           ,1
           ,'DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl'
           ,NULL)

           ,(11
           ,0
           ,'DataType_Integer_Editor'
           ,'Editor for Datatype Integer'
           ,1
           ,'DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl'
           ,NULL)

           ,(12
           ,0
           ,'DataType_Float_Editor'
           ,'Editor for Datatype Float'
           ,1
           ,'DevComponents.DotNetBar.SuperGrid.GridDoubleInputEditControl'
           ,NULL)

           ,(13
           ,0
           ,'DataType_Logical_Editor'
           ,'Editor for Datatype Logical'
           ,1
           ,'DevComponents.DotNetBar.SuperGrid.GridDoubleInputEditControl'
           ,NULL)

           ,(14
           ,0
           ,'DataType_Comment_Editor'
           ,'Editor for Datatype Comment'
           ,1
           ,'DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl'
           ,NULL)

           ,(15
           ,0
           ,'DataType_ArrayInteger_Editor'
           ,'Editor for Datatype ArrayInteger'
           ,1
           ,'DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl'
           ,NULL)

           ,(16
           ,0
           ,'DataType_ArrayFloat_Editor'
           ,'Editor for Datatype ArrayFloat'
           ,1
           ,'DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl'
           ,NULL)

           ,(17
           ,0
           ,'DataType_ArrayString_Editor'
           ,'Editor for Datatype ArrayString'
           ,1
           ,'DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl'
           ,NULL)

           ,(18
           ,0
           ,'DataType_Boolean_Editor'
           ,'Editor for Datatype Boolean'
           ,1
           ,'DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl'
           ,NULL)

           ,(19
           ,0
           ,'DataType_Color_Editor'
           ,'Editor for Datatype Color'
           ,1
           ,'DevComponents.DotNetBar.SuperGrid.GridColorPickerEditControl'
           ,NULL)

           ,(20
           ,0
           ,'DataType_List_Editor'
           ,'Editor for Datatype List'
           ,1
           ,'Actemium.EmptyClient.Client.General.UserControls.GridEditControls.GridListComboBoxExEditControl'
           ,NULL)

           ,(21
           ,0
           ,'DataType_DateTime_Editor'
           ,'Editor for Datatype DateTime'
           ,1
           ,'DevComponents.DotNetBar.SuperGrid.GridDateTimeInputEditControl'
           ,NULL)

           ,(22
           ,0
           ,'DataType_Image_Editor'
           ,'Editor for Datatype Image'
           ,1
           ,'DevComponents.DotNetBar.SuperGrid.GridImageEditControl'
           ,NULL)

           ,(23
           ,0
           ,'DataType_IpAdress_Editor'
           ,'Editor for Datatype IpAdress'
           ,1
           ,'DevComponents.DotNetBar.SuperGrid.GridIpAddressInputEditControl'
           ,NULL)

            ,(1003
           ,1000
           ,'MaintenanceMode'
           ,'Application in maintenance mode'
           ,9
           ,'False'
           ,NULL)

           ,(1004
           ,1000
           ,'VisibleHistoryActionCount'
           ,'Number of visible History Actions in the client'
           ,2
           ,'10'
           ,NULL)

           ,(1006
           ,1000
           ,'ApplicationName'
           ,'The name of the application'
           ,1
           ,''
           ,NULL)

           ,(1007
           ,1000
           ,'ApplicationSite'
           ,'The name of the site, where the application is installed'
           ,9
           ,''
           ,NULL)

           ,(3001
           ,3000
           ,'EmptyPasswordAllowed'
           ,'Allow the use of empty passwords'
           ,9
           ,'True'
           ,NULL)


GO
           INSERT INTO [AS].ApplicationSettings (ApplicationSettingId, ApplicationSettingsCategoryId, Name, Description, DataTypeId, Value) VALUES (2004, 2000 /*Languages*/, 'Language_ps-AF_Active', 'Set language Pashto - Afghanistan to active/inactive', 9 /*Boolean*/, 'False', NULL),(2005, 2000 /*Languages*/, 'Language_prs-AF_Active', 'Set language Dari - Afghanistan to active/inactive', 9 /*Boolean*/, 'False', NULL),(2006, 2000 /*Languages*/, 'Language_sq-AL_Active', 'Set language Albanian - Albania to active/inactive', 9 /*Boolean*/, 'False', NULL),(2007, 2000 /*Languages*/, 'Language_ar-DZ_Active', 'Set language Arabic - Algeria to active/inactive', 9 /*Boolean*/, 'False', NULL),(2008, 2000 /*Languages*/, 'Language_es-AR_Active', 'Set language Spanish - Argentina to active/inactive', 9 /*Boolean*/, 'False', NULL),(2009, 2000 /*Languages*/, 'Language_hy-AM_Active', 'Set language Armenian - Armenia to active/inactive', 9 /*Boolean*/, 'False', NULL),(2010, 2000 /*Languages*/, 'Language_en-AU_Active', 'Set language English - Australia to active/inactive', 9 /*Boolean*/, 'False', NULL),(2011, 2000 /*Languages*/, 'Language_de-AT_Active', 'Set language German - Austria to active/inactive', 9 /*Boolean*/, 'False', NULL),(2012, 2000 /*Languages*/, 'Language_ar-BH_Active', 'Set language Arabic - Bahrain to active/inactive', 9 /*Boolean*/, 'False', NULL),(2013, 2000 /*Languages*/, 'Language_bn-BD_Active', 'Set language Bengali - Bangladesh to active/inactive', 9 /*Boolean*/, 'False', NULL),(2014, 2000 /*Languages*/, 'Language_eu-ES_Active', 'Set language Basque - Basque to active/inactive', 9 /*Boolean*/, 'False', NULL),(2015, 2000 /*Languages*/, 'Language_be-BY_Active', 'Set language Belarusian - Belarus to active/inactive', 9 /*Boolean*/, 'False', NULL),(2016, 2000 /*Languages*/, 'Language_fr-BE_Active', 'Set language French - Belgium to active/inactive', 9 /*Boolean*/, 'False', NULL),(2017, 2000 /*Languages*/, 'Language_nl-BE_Active', 'Set language Dutch - Belgium to active/inactive', 9 /*Boolean*/, 'False', NULL),(2018, 2000 /*Languages*/, 'Language_en-BZ_Active', 'Set language English - Belize to active/inactive', 9 /*Boolean*/, 'False', NULL),(2019, 2000 /*Languages*/, 'Language_es-VE_Active', 'Set language Spanish - Bolivarian Republic of Venezuela to active/inactive', 9 /*Boolean*/, 'False', NULL),(2020, 2000 /*Languages*/, 'Language_quz-BO_Active', 'Set language Quechua - Bolivia to active/inactive', 9 /*Boolean*/, 'False', NULL),(2021, 2000 /*Languages*/, 'Language_es-BO_Active', 'Set language Spanish - Bolivia to active/inactive', 9 /*Boolean*/, 'False', NULL),(2022, 2000 /*Languages*/, 'Language_pt-BR_Active', 'Set language Portuguese - Brazil to active/inactive', 9 /*Boolean*/, 'False', NULL),(2023, 2000 /*Languages*/, 'Language_ms-BN_Active', 'Set language Malay - Brunei Darussalam to active/inactive', 9 /*Boolean*/, 'False', NULL),(2024, 2000 /*Languages*/, 'Language_bg-BG_Active', 'Set language Bulgarian - Bulgaria to active/inactive', 9 /*Boolean*/, 'False', NULL),(2025, 2000 /*Languages*/, 'Language_km-KH_Active', 'Set language Khmer - Cambodia to active/inactive', 9 /*Boolean*/, 'False', NULL),(2026, 2000 /*Languages*/, 'Language_fr-CA_Active', 'Set language French - Canada to active/inactive', 9 /*Boolean*/, 'False', NULL),(2027, 2000 /*Languages*/, 'Language_en-CA_Active', 'Set language English - Canada to active/inactive', 9 /*Boolean*/, 'False', NULL),(2028, 2000 /*Languages*/, 'Language_en-029_Active', 'Set language English - Caribbean to active/inactive', 9 /*Boolean*/, 'False', NULL),(2029, 2000 /*Languages*/, 'Language_ca-ES_Active', 'Set language Catalan - Catalan to active/inactive', 9 /*Boolean*/, 'False', NULL),(2030, 2000 /*Languages*/, 'Language_arn-CL_Active', 'Set language Mapudungun - Chile to active/inactive', 9 /*Boolean*/, 'False', NULL),(2031, 2000 /*Languages*/, 'Language_es-CL_Active', 'Set language Spanish - Chile to active/inactive', 9 /*Boolean*/, 'False', NULL),(2032, 2000 /*Languages*/, 'Language_es-CO_Active', 'Set language Spanish - Colombia to active/inactive', 9 /*Boolean*/, 'False', NULL),(2033, 2000 /*Languages*/, 'Language_es-CR_Active', 'Set language Spanish - Costa Rica to active/inactive', 9 /*Boolean*/, 'False', NULL),(2034, 2000 /*Languages*/, 'Language_hr-HR_Active', 'Set language Croatian - Croatia to active/inactive', 9 /*Boolean*/, 'False', NULL),(2035, 2000 /*Languages*/, 'Language_az-Cyrl-AZ_Active', 'Set language Azeri - Cyrillic, Azerbaijan to active/inactive', 9 /*Boolean*/, 'False', NULL),(2036, 2000 /*Languages*/, 'Language_sr-Cyrl-BA_Active', 'Set language Serbian - Cyrillic, Bosnia and Herzegovina to active/inactive', 9 /*Boolean*/, 'False', NULL),(2037, 2000 /*Languages*/, 'Language_bs-Cyrl-BA_Active', 'Set language Bosnian - Cyrillic, Bosnia and Herzegovina to active/inactive', 9 /*Boolean*/, 'False', NULL),(2038, 2000 /*Languages*/, 'Language_mn-MN_Active', 'Set language Mongolian - Cyrillic, Mongolia to active/inactive', 9 /*Boolean*/, 'False', NULL),(2039, 2000 /*Languages*/, 'Language_sr-Cyrl-ME_Active', 'Set language Serbian - Cyrillic, Montenegro to active/inactive', 9 /*Boolean*/, 'False', NULL),(2040, 2000 /*Languages*/, 'Language_sr-Cyrl-RS_Active', 'Set language Serbian - Cyrillic, Serbia to active/inactive', 9 /*Boolean*/, 'False', NULL),(2041, 2000 /*Languages*/, 'Language_sr-Cyrl-CS_Active', 'Set language Serbian - Cyrillic, Serbia and Montenegro (Former to active/inactive', 9 /*Boolean*/, 'False', NULL),(2042, 2000 /*Languages*/, 'Language_tg-Cyrl-TJ_Active', 'Set language Tajik - Cyrillic, Tajikistan to active/inactive', 9 /*Boolean*/, 'False', NULL),(2043, 2000 /*Languages*/, 'Language_uz-Cyrl-UZ_Active', 'Set language Uzbek - Cyrillic, Uzbekistan to active/inactive', 9 /*Boolean*/, 'False', NULL),(2044, 2000 /*Languages*/, 'Language_cs-CZ_Active', 'Set language Czech - Czech Republic to active/inactive', 9 /*Boolean*/, 'False', NULL),(2045, 2000 /*Languages*/, 'Language_da-DK_Active', 'Set language Danish - Denmark to active/inactive', 9 /*Boolean*/, 'False', NULL),(2046, 2000 /*Languages*/, 'Language_es-DO_Active', 'Set language Spanish - Dominican Republic to active/inactive', 9 /*Boolean*/, 'False', NULL),(2047, 2000 /*Languages*/, 'Language_quz-EC_Active', 'Set language Quechua - Ecuador to active/inactive', 9 /*Boolean*/, 'False', NULL),(2048, 2000 /*Languages*/, 'Language_es-EC_Active', 'Set language Spanish - Ecuador to active/inactive', 9 /*Boolean*/, 'False', NULL),(2049, 2000 /*Languages*/, 'Language_ar-EG_Active', 'Set language Arabic - Egypt to active/inactive', 9 /*Boolean*/, 'False', NULL),(2050, 2000 /*Languages*/, 'Language_es-SV_Active', 'Set language Spanish - El Salvador to active/inactive', 9 /*Boolean*/, 'False', NULL),(2051, 2000 /*Languages*/, 'Language_et-EE_Active', 'Set language Estonian - Estonia to active/inactive', 9 /*Boolean*/, 'False', NULL),(2052, 2000 /*Languages*/, 'Language_am-ET_Active', 'Set language Amharic - Ethiopia to active/inactive', 9 /*Boolean*/, 'False', NULL),(2053, 2000 /*Languages*/, 'Language_fo-FO_Active', 'Set language Faroese - Faroe Islands to active/inactive', 9 /*Boolean*/, 'False', NULL),(2054, 2000 /*Languages*/, 'Language_fi-FI_Active', 'Set language Finnish - Finland to active/inactive', 9 /*Boolean*/, 'False', NULL),(2055, 2000 /*Languages*/, 'Language_sv-FI_Active', 'Set language Swedish - Finland to active/inactive', 9 /*Boolean*/, 'False', NULL),(2056, 2000 /*Languages*/, 'Language_se-FI_Active', 'Set language Sami, Northern - Finland to active/inactive', 9 /*Boolean*/, 'False', NULL),(2057, 2000 /*Languages*/, 'Language_sms-FI_Active', 'Set language Sami, Skolt - Finland to active/inactive', 9 /*Boolean*/, 'False', NULL),(2058, 2000 /*Languages*/, 'Language_smn-FI_Active', 'Set language Sami, Inari - Finland to active/inactive', 9 /*Boolean*/, 'False', NULL),(2059, 2000 /*Languages*/, 'Language_mk-MK_Active', 'Set language Macedonian - Former Yugoslav Republic of Macedonia to active/inactive', 9 /*Boolean*/, 'False', NULL),(2060, 2000 /*Languages*/, 'Language_fr-FR_Active', 'Set language French - France to active/inactive', 9 /*Boolean*/, 'False', NULL),(2061, 2000 /*Languages*/, 'Language_br-FR_Active', 'Set language Breton - France to active/inactive', 9 /*Boolean*/, 'False', NULL),(2062, 2000 /*Languages*/, 'Language_oc-FR_Active', 'Set language Occitan - France to active/inactive', 9 /*Boolean*/, 'False', NULL),(2063, 2000 /*Languages*/, 'Language_co-FR_Active', 'Set language Corsican - France to active/inactive', 9 /*Boolean*/, 'False', NULL),(2064, 2000 /*Languages*/, 'Language_gsw-FR_Active', 'Set language Alsatian - France to active/inactive', 9 /*Boolean*/, 'False', NULL),(2065, 2000 /*Languages*/, 'Language_gl-ES_Active', 'Set language Galician - Galician to active/inactive', 9 /*Boolean*/, 'False', NULL),(2066, 2000 /*Languages*/, 'Language_ka-GE_Active', 'Set language Georgian - Georgia to active/inactive', 9 /*Boolean*/, 'False', NULL),(2067, 2000 /*Languages*/, 'Language_de-DE_Active', 'Set language German - Germany to active/inactive', 9 /*Boolean*/, 'False', NULL),(2068, 2000 /*Languages*/, 'Language_hsb-DE_Active', 'Set language Upper Sorbian - Germany to active/inactive', 9 /*Boolean*/, 'False', NULL),(2069, 2000 /*Languages*/, 'Language_dsb-DE_Active', 'Set language Lower Sorbian - Germany to active/inactive', 9 /*Boolean*/, 'False', NULL),(2070, 2000 /*Languages*/, 'Language_el-GR_Active', 'Set language Greek - Greece to active/inactive', 9 /*Boolean*/, 'False', NULL),(2071, 2000 /*Languages*/, 'Language_kl-GL_Active', 'Set language Greenlandic - Greenland to active/inactive', 9 /*Boolean*/, 'False', NULL),(2072, 2000 /*Languages*/, 'Language_qut-GT_Active', 'Set language Kiche - Guatemala to active/inactive', 9 /*Boolean*/, 'False', NULL),(2073, 2000 /*Languages*/, 'Language_es-GT_Active', 'Set language Spanish - Guatemala to active/inactive', 9 /*Boolean*/, 'False', NULL),(2074, 2000 /*Languages*/, 'Language_es-HN_Active', 'Set language Spanish - Honduras to active/inactive', 9 /*Boolean*/, 'False', NULL),(2075, 2000 /*Languages*/, 'Language_hu-HU_Active', 'Set language Hungarian - Hungary to active/inactive', 9 /*Boolean*/, 'False', NULL),(2076, 2000 /*Languages*/, 'Language_is-IS_Active', 'Set language Icelandic - Iceland to active/inactive', 9 /*Boolean*/, 'False', NULL),(2077, 2000 /*Languages*/, 'Language_hi-IN_Active', 'Set language Hindi - India to active/inactive', 9 /*Boolean*/, 'False', NULL),(2078, 2000 /*Languages*/, 'Language_bn-IN_Active', 'Set language Bengali - India to active/inactive', 9 /*Boolean*/, 'False', NULL),(2079, 2000 /*Languages*/, 'Language_pa-IN_Active', 'Set language Punjabi - India to active/inactive', 9 /*Boolean*/, 'False', NULL),(2080, 2000 /*Languages*/, 'Language_gu-IN_Active', 'Set language Gujarati - India to active/inactive', 9 /*Boolean*/, 'False', NULL),(2081, 2000 /*Languages*/, 'Language_or-IN_Active', 'Set language Oriya - India to active/inactive', 9 /*Boolean*/, 'False', NULL),(2082, 2000 /*Languages*/, 'Language_ta-IN_Active', 'Set language Tamil - India to active/inactive', 9 /*Boolean*/, 'False', NULL),(2083, 2000 /*Languages*/, 'Language_te-IN_Active', 'Set language Telugu - India to active/inactive', 9 /*Boolean*/, 'False', NULL),(2084, 2000 /*Languages*/, 'Language_kn-IN_Active', 'Set language Kannada - India to active/inactive', 9 /*Boolean*/, 'False', NULL),(2085, 2000 /*Languages*/, 'Language_ml-IN_Active', 'Set language Malayalam - India to active/inactive', 9 /*Boolean*/, 'False', NULL),(2086, 2000 /*Languages*/, 'Language_as-IN_Active', 'Set language Assamese - India to active/inactive', 9 /*Boolean*/, 'False', NULL),(2087, 2000 /*Languages*/, 'Language_mr-IN_Active', 'Set language Marathi - India to active/inactive', 9 /*Boolean*/, 'False', NULL),(2088, 2000 /*Languages*/, 'Language_sa-IN_Active', 'Set language Sanskrit - India to active/inactive', 9 /*Boolean*/, 'False', NULL),(2089, 2000 /*Languages*/, 'Language_kok-IN_Active', 'Set language Konkani - India to active/inactive', 9 /*Boolean*/, 'False', NULL),(2090, 2000 /*Languages*/, 'Language_en-IN_Active', 'Set language English - India to active/inactive', 9 /*Boolean*/, 'False', NULL),(2091, 2000 /*Languages*/, 'Language_id-ID_Active', 'Set language Indonesian - Indonesia to active/inactive', 9 /*Boolean*/, 'False', NULL),(2092, 2000 /*Languages*/, 'Language_fa-IR_Active', 'Set language Persian - Iran to active/inactive', 9 /*Boolean*/, 'False', NULL),(2093, 2000 /*Languages*/, 'Language_ar-IQ_Active', 'Set language Arabic - Iraq to active/inactive', 9 /*Boolean*/, 'False', NULL),(2094, 2000 /*Languages*/, 'Language_ga-IE_Active', 'Set language Irish - Ireland to active/inactive', 9 /*Boolean*/, 'False', NULL),(2095, 2000 /*Languages*/, 'Language_en-IE_Active', 'Set language English - Ireland to active/inactive', 9 /*Boolean*/, 'False', NULL),(2096, 2000 /*Languages*/, 'Language_ur-PK_Active', 'Set language Urdu - Islamic Republic of Pakistan to active/inactive', 9 /*Boolean*/, 'False', NULL),(2097, 2000 /*Languages*/, 'Language_he-IL_Active', 'Set language Hebrew - Israel to active/inactive', 9 /*Boolean*/, 'False', NULL),(2098, 2000 /*Languages*/, 'Language_it-IT_Active', 'Set language Italian - Italy to active/inactive', 9 /*Boolean*/, 'False', NULL),(2099, 2000 /*Languages*/, 'Language_en-JM_Active', 'Set language English - Jamaica to active/inactive', 9 /*Boolean*/, 'False', NULL),(2100, 2000 /*Languages*/, 'Language_ja-JP_Active', 'Set language Japanese - Japan to active/inactive', 9 /*Boolean*/, 'False', NULL),(2101, 2000 /*Languages*/, 'Language_ar-JO_Active', 'Set language Arabic - Jordan to active/inactive', 9 /*Boolean*/, 'False', NULL),(2102, 2000 /*Languages*/, 'Language_kk-KZ_Active', 'Set language Kazakh - Kazakhstan to active/inactive', 9 /*Boolean*/, 'False', NULL),(2103, 2000 /*Languages*/, 'Language_sw-KE_Active', 'Set language Kiswahili - Kenya to active/inactive', 9 /*Boolean*/, 'False', NULL),(2104, 2000 /*Languages*/, 'Language_ko-KR_Active', 'Set language Korean - Korea to active/inactive', 9 /*Boolean*/, 'False', NULL),(2105, 2000 /*Languages*/, 'Language_ar-KW_Active', 'Set language Arabic - Kuwait to active/inactive', 9 /*Boolean*/, 'False', NULL),(2106, 2000 /*Languages*/, 'Language_ky-KG_Active', 'Set language Kyrgyz - Kyrgyzstan to active/inactive', 9 /*Boolean*/, 'False', NULL),(2107, 2000 /*Languages*/, 'Language_lo-LA_Active', 'Set language Lao - Lao P.D.R. to active/inactive', 9 /*Boolean*/, 'False', NULL),(2108, 2000 /*Languages*/, 'Language_tzm-Lat-DZ_Active', 'Set language Tamazight - Latin, Algeria to active/inactive', 9 /*Boolean*/, 'False', NULL),(2109, 2000 /*Languages*/, 'Language_az-Latn-AZ_Active', 'Set language Azeri - Latin, Azerbaijan to active/inactive', 9 /*Boolean*/, 'False', NULL),(2110, 2000 /*Languages*/, 'Language_hr-BA_Active', 'Set language Croatian - Latin, Bosnia and Herzegovina to active/inactive', 9 /*Boolean*/, 'False', NULL),(2111, 2000 /*Languages*/, 'Language_bs-Latn-BA_Active', 'Set language Bosnian - Latin, Bosnia and Herzegovina to active/inactive', 9 /*Boolean*/, 'False', NULL),(2112, 2000 /*Languages*/, 'Language_sr-Latn-BA_Active', 'Set language Serbian - Latin, Bosnia and Herzegovina to active/inactive', 9 /*Boolean*/, 'False', NULL),(2113, 2000 /*Languages*/, 'Language_iu-Latn-CA_Active', 'Set language Inuktitut - Latin, Canada to active/inactive', 9 /*Boolean*/, 'False', NULL),(2114, 2000 /*Languages*/, 'Language_sr-Latn-ME_Active', 'Set language Serbian - Latin, Montenegro to active/inactive', 9 /*Boolean*/, 'False', NULL),(2115, 2000 /*Languages*/, 'Language_ha-Latn-NG_Active', 'Set language Hausa - Latin, Nigeria to active/inactive', 9 /*Boolean*/, 'False', NULL),(2116, 2000 /*Languages*/, 'Language_sr-Latn-RS_Active', 'Set language Serbian - Latin, Serbia to active/inactive', 9 /*Boolean*/, 'False', NULL),(2117, 2000 /*Languages*/, 'Language_sr-Latn-CS_Active', 'Set language Serbian ) - Latin, Serbia and Montenegro (Former to active/inactive', 9 /*Boolean*/, 'False', NULL),(2118, 2000 /*Languages*/, 'Language_uz-Latn-UZ_Active', 'Set language Uzbek - Latin, Uzbekistan to active/inactive', 9 /*Boolean*/, 'False', NULL),(2119, 2000 /*Languages*/, 'Language_lv-LV_Active', 'Set language Latvian - Latvia to active/inactive', 9 /*Boolean*/, 'False', NULL),(2120, 2000 /*Languages*/, 'Language_ar-LB_Active', 'Set language Arabic - Lebanon to active/inactive', 9 /*Boolean*/, 'False', NULL),(2121, 2000 /*Languages*/, 'Language_ar-LY_Active', 'Set language Arabic - Libya to active/inactive', 9 /*Boolean*/, 'False', NULL),(2122, 2000 /*Languages*/, 'Language_de-LI_Active', 'Set language German - Liechtenstein to active/inactive', 9 /*Boolean*/, 'False', NULL),(2123, 2000 /*Languages*/, 'Language_lt-LT_Active', 'Set language Lithuanian - Lithuania to active/inactive', 9 /*Boolean*/, 'False', NULL),(2124, 2000 /*Languages*/, 'Language_lb-LU_Active', 'Set language Luxembourgish - Luxembourg to active/inactive', 9 /*Boolean*/, 'False', NULL),(2125, 2000 /*Languages*/, 'Language_de-LU_Active', 'Set language German - Luxembourg to active/inactive', 9 /*Boolean*/, 'False', NULL),(2126, 2000 /*Languages*/, 'Language_fr-LU_Active', 'Set language French - Luxembourg to active/inactive', 9 /*Boolean*/, 'False', NULL),(2127, 2000 /*Languages*/, 'Language_ms-MY_Active', 'Set language Malay - Malaysia to active/inactive', 9 /*Boolean*/, 'False', NULL),(2128, 2000 /*Languages*/, 'Language_en-MY_Active', 'Set language English - Malaysia to active/inactive', 9 /*Boolean*/, 'False', NULL),(2129, 2000 /*Languages*/, 'Language_dv-MV_Active', 'Set language Divehi - Maldives to active/inactive', 9 /*Boolean*/, 'False', NULL),(2130, 2000 /*Languages*/, 'Language_mt-MT_Active', 'Set language Maltese - Malta to active/inactive', 9 /*Boolean*/, 'False', NULL),(2131, 2000 /*Languages*/, 'Language_es-MX_Active', 'Set language Spanish - Mexico to active/inactive', 9 /*Boolean*/, 'False', NULL),(2132, 2000 /*Languages*/, 'Language_moh-CA_Active', 'Set language Mohawk - Mohawk to active/inactive', 9 /*Boolean*/, 'False', NULL),(2133, 2000 /*Languages*/, 'Language_fr-MC_Active', 'Set language French - Monaco to active/inactive', 9 /*Boolean*/, 'False', NULL),(2134, 2000 /*Languages*/, 'Language_ar-MA_Active', 'Set language Arabic - Morocco to active/inactive', 9 /*Boolean*/, 'False', NULL),(2135, 2000 /*Languages*/, 'Language_ne-NP_Active', 'Set language Nepali - Nepal to active/inactive', 9 /*Boolean*/, 'False', NULL),(2003, 2000 /*Languages*/, 'Language_nl-NL_Active', 'Set language Dutch - Netherlands to active/inactive', 9 /*Boolean*/, 'True', NULL),(2137, 2000 /*Languages*/, 'Language_fy-NL_Active', 'Set language Frisian - Netherlands to active/inactive', 9 /*Boolean*/, 'False', NULL),(2138, 2000 /*Languages*/, 'Language_mi-NZ_Active', 'Set language Maori - New Zealand to active/inactive', 9 /*Boolean*/, 'False', NULL),(2139, 2000 /*Languages*/, 'Language_en-NZ_Active', 'Set language English - New Zealand to active/inactive', 9 /*Boolean*/, 'False', NULL),(2140, 2000 /*Languages*/, 'Language_es-NI_Active', 'Set language Spanish - Nicaragua to active/inactive', 9 /*Boolean*/, 'False', NULL),(2141, 2000 /*Languages*/, 'Language_yo-NG_Active', 'Set language Yoruba - Nigeria to active/inactive', 9 /*Boolean*/, 'False', NULL),(2142, 2000 /*Languages*/, 'Language_ig-NG_Active', 'Set language Igbo - Nigeria to active/inactive', 9 /*Boolean*/, 'False', NULL),(2143, 2000 /*Languages*/, 'Language_nb-NO_Active', 'Set language Norwegian, Bokmål - Norway to active/inactive', 9 /*Boolean*/, 'False', NULL),(2144, 2000 /*Languages*/, 'Language_se-NO_Active', 'Set language Sami, Northern - Norway to active/inactive', 9 /*Boolean*/, 'False', NULL),(2145, 2000 /*Languages*/, 'Language_nn-NO_Active', 'Set language Norwegian, Nynorsk - Norway to active/inactive', 9 /*Boolean*/, 'False', NULL),(2146, 2000 /*Languages*/, 'Language_smj-NO_Active', 'Set language Sami, Lule - Norway to active/inactive', 9 /*Boolean*/, 'False', NULL),(2147, 2000 /*Languages*/, 'Language_sma-NO_Active', 'Set language Sami, Southern - Norway to active/inactive', 9 /*Boolean*/, 'False', NULL),(2148, 2000 /*Languages*/, 'Language_ar-OM_Active', 'Set language Arabic - Oman to active/inactive', 9 /*Boolean*/, 'False', NULL),(2149, 2000 /*Languages*/, 'Language_es-PA_Active', 'Set language Spanish - Panama to active/inactive', 9 /*Boolean*/, 'False', NULL),(2150, 2000 /*Languages*/, 'Language_es-PY_Active', 'Set language Spanish - Paraguay to active/inactive', 9 /*Boolean*/, 'False', NULL),(2151, 2000 /*Languages*/, 'Language_quz-PE_Active', 'Set language Quechua - Peru to active/inactive', 9 /*Boolean*/, 'False', NULL),(2152, 2000 /*Languages*/, 'Language_es-PE_Active', 'Set language Spanish - Peru to active/inactive', 9 /*Boolean*/, 'False', NULL),(2153, 2000 /*Languages*/, 'Language_fil-PH_Active', 'Set language Filipino - Philippines to active/inactive', 9 /*Boolean*/, 'False', NULL),(2154, 2000 /*Languages*/, 'Language_pl-PL_Active', 'Set language Polish - Poland to active/inactive', 9 /*Boolean*/, 'False', NULL),(2155, 2000 /*Languages*/, 'Language_pt-PT_Active', 'Set language Portuguese - Portugal to active/inactive', 9 /*Boolean*/, 'False', NULL),(2156, 2000 /*Languages*/, 'Language_bo-CN_Active', 'Set language Tibetan - PRC to active/inactive', 9 /*Boolean*/, 'False', NULL),(2157, 2000 /*Languages*/, 'Language_ii-CN_Active', 'Set language Yi - PRC to active/inactive', 9 /*Boolean*/, 'False', NULL),(2158, 2000 /*Languages*/, 'Language_ug-CN_Active', 'Set language Uyghur - PRC to active/inactive', 9 /*Boolean*/, 'False', NULL),(2159, 2000 /*Languages*/, 'Language_es-PR_Active', 'Set language Spanish - Puerto Rico to active/inactive', 9 /*Boolean*/, 'False', NULL),(2160, 2000 /*Languages*/, 'Language_ar-QA_Active', 'Set language Arabic - Qatar to active/inactive', 9 /*Boolean*/, 'False', NULL),(2161, 2000 /*Languages*/, 'Language_en-PH_Active', 'Set language English - Republic of the Philippines to active/inactive', 9 /*Boolean*/, 'False', NULL),(2162, 2000 /*Languages*/, 'Language_ro-RO_Active', 'Set language Romanian - Romania to active/inactive', 9 /*Boolean*/, 'False', NULL),(2163, 2000 /*Languages*/, 'Language_ru-RU_Active', 'Set language Russian - Russia to active/inactive', 9 /*Boolean*/, 'False', NULL),(2164, 2000 /*Languages*/, 'Language_tt-RU_Active', 'Set language Tatar - Russia to active/inactive', 9 /*Boolean*/, 'False', NULL),(2165, 2000 /*Languages*/, 'Language_ba-RU_Active', 'Set language Bashkir - Russia to active/inactive', 9 /*Boolean*/, 'False', NULL),(2166, 2000 /*Languages*/, 'Language_sah-RU_Active', 'Set language Yakut - Russia to active/inactive', 9 /*Boolean*/, 'False', NULL),(2167, 2000 /*Languages*/, 'Language_rw-RW_Active', 'Set language Kinyarwanda - Rwanda to active/inactive', 9 /*Boolean*/, 'False', NULL),(2168, 2000 /*Languages*/, 'Language_ar-SA_Active', 'Set language Arabic - Saudi Arabia to active/inactive', 9 /*Boolean*/, 'False', NULL),(2169, 2000 /*Languages*/, 'Language_wo-SN_Active', 'Set language Wolof - Senegal to active/inactive', 9 /*Boolean*/, 'False', NULL),(2170, 2000 /*Languages*/, 'Language_zh-CN_Active', 'Set language Chinese - Simplified, PRC to active/inactive', 9 /*Boolean*/, 'False', NULL),(2171, 2000 /*Languages*/, 'Language_zh-SG_Active', 'Set language Chinese - Simplified, Singapore to active/inactive', 9 /*Boolean*/, 'False', NULL),(2172, 2000 /*Languages*/, 'Language_en-SG_Active', 'Set language English - Singapore to active/inactive', 9 /*Boolean*/, 'False', NULL),(2173, 2000 /*Languages*/, 'Language_sk-SK_Active', 'Set language Slovak - Slovakia to active/inactive', 9 /*Boolean*/, 'False', NULL),(2174, 2000 /*Languages*/, 'Language_sl-SI_Active', 'Set language Slovenian - Slovenia to active/inactive', 9 /*Boolean*/, 'False', NULL),(2175, 2000 /*Languages*/, 'Language_tn-ZA_Active', 'Set language Setswana - South Africa to active/inactive', 9 /*Boolean*/, 'False', NULL),(2176, 2000 /*Languages*/, 'Language_xh-ZA_Active', 'Set language isiXhosa - South Africa to active/inactive', 9 /*Boolean*/, 'False', NULL),(2177, 2000 /*Languages*/, 'Language_zu-ZA_Active', 'Set language isiZulu - South Africa to active/inactive', 9 /*Boolean*/, 'False', NULL),(2178, 2000 /*Languages*/, 'Language_af-ZA_Active', 'Set language Afrikaans - South Africa to active/inactive', 9 /*Boolean*/, 'False', NULL),(2179, 2000 /*Languages*/, 'Language_nso-ZA_Active', 'Set language Sesotho sa Leboa - South Africa to active/inactive', 9 /*Boolean*/, 'False', NULL),(2180, 2000 /*Languages*/, 'Language_en-ZA_Active', 'Set language English - South Africa to active/inactive', 9 /*Boolean*/, 'False', NULL),(2181, 2000 /*Languages*/, 'Language_es-ES_Active', 'Set language Spanish - Spain, International Sort to active/inactive', 9 /*Boolean*/, 'False', NULL),(2182, 2000 /*Languages*/, 'Language_si-LK_Active', 'Set language Sinhala - Sri Lanka to active/inactive', 9 /*Boolean*/, 'False', NULL),(2183, 2000 /*Languages*/, 'Language_sv-SE_Active', 'Set language Swedish - Sweden to active/inactive', 9 /*Boolean*/, 'False', NULL),(2184, 2000 /*Languages*/, 'Language_se-SE_Active', 'Set language Sami, Northern - Sweden to active/inactive', 9 /*Boolean*/, 'False', NULL),(2185, 2000 /*Languages*/, 'Language_smj-SE_Active', 'Set language Sami, Lule - Sweden to active/inactive', 9 /*Boolean*/, 'False', NULL),(2186, 2000 /*Languages*/, 'Language_sma-SE_Active', 'Set language Sami, Southern - Sweden to active/inactive', 9 /*Boolean*/, 'False', NULL),(2187, 2000 /*Languages*/, 'Language_rm-CH_Active', 'Set language Romansh - Switzerland to active/inactive', 9 /*Boolean*/, 'False', NULL),(2188, 2000 /*Languages*/, 'Language_de-CH_Active', 'Set language German - Switzerland to active/inactive', 9 /*Boolean*/, 'False', NULL),(2189, 2000 /*Languages*/, 'Language_it-CH_Active', 'Set language Italian - Switzerland to active/inactive', 9 /*Boolean*/, 'False', NULL),(2190, 2000 /*Languages*/, 'Language_fr-CH_Active', 'Set language French - Switzerland to active/inactive', 9 /*Boolean*/, 'False', NULL),(2191, 2000 /*Languages*/, 'Language_iu-Cans-CA_Active', 'Set language Inuktitut - Syllabics, Canada to active/inactive', 9 /*Boolean*/, 'False', NULL),(2192, 2000 /*Languages*/, 'Language_syr-SY_Active', 'Set language Syriac - Syria to active/inactive', 9 /*Boolean*/, 'False', NULL),(2193, 2000 /*Languages*/, 'Language_ar-SY_Active', 'Set language Arabic - Syria to active/inactive', 9 /*Boolean*/, 'False', NULL),(2194, 2000 /*Languages*/, 'Language_th-TH_Active', 'Set language Thai - Thailand to active/inactive', 9 /*Boolean*/, 'False', NULL),(2195, 2000 /*Languages*/, 'Language_mn-Mong-CN_Active', 'Set language Mongolian - Traditional Mongolian, PRC to active/inactive', 9 /*Boolean*/, 'False', NULL),(2196, 2000 /*Languages*/, 'Language_zh-HK_Active', 'Set language Chinese - Traditional, Hong Kong S.A.R. to active/inactive', 9 /*Boolean*/, 'False', NULL),(2197, 2000 /*Languages*/, 'Language_zh-MO_Active', 'Set language Chinese - Traditional, Macao S.A.R. to active/inactive', 9 /*Boolean*/, 'False', NULL),(2198, 2000 /*Languages*/, 'Language_zh-TW_Active', 'Set language Chinese - Traditional, Taiwan to active/inactive', 9 /*Boolean*/, 'False', NULL),(2199, 2000 /*Languages*/, 'Language_en-TT_Active', 'Set language English - Trinidad and Tobago to active/inactive', 9 /*Boolean*/, 'False', NULL),(2200, 2000 /*Languages*/, 'Language_ar-TN_Active', 'Set language Arabic - Tunisia to active/inactive', 9 /*Boolean*/, 'False', NULL),(2201, 2000 /*Languages*/, 'Language_tr-TR_Active', 'Set language Turkish - Turkey to active/inactive', 9 /*Boolean*/, 'False', NULL),(2202, 2000 /*Languages*/, 'Language_tk-TM_Active', 'Set language Turkmen - Turkmenistan to active/inactive', 9 /*Boolean*/, 'False', NULL),(2203, 2000 /*Languages*/, 'Language_ar-AE_Active', 'Set language Arabic - U.A.E. to active/inactive', 9 /*Boolean*/, 'False', NULL),(2204, 2000 /*Languages*/, 'Language_uk-UA_Active', 'Set language Ukrainian - Ukraine to active/inactive', 9 /*Boolean*/, 'False', NULL),(2205, 2000 /*Languages*/, 'Language_cy-GB_Active', 'Set language Welsh - United Kingdom to active/inactive', 9 /*Boolean*/, 'False', NULL),(2206, 2000 /*Languages*/, 'Language_gd-GB_Active', 'Set language Scottish Gaelic - United Kingdom to active/inactive', 9 /*Boolean*/, 'False', NULL),(2001, 2000 /*Languages*/, 'Language_en-GB_Active', 'Set language English - United Kingdom to active/inactive', 9 /*Boolean*/, 'True', NULL),(2208, 2000 /*Languages*/, 'Language_en-US_Active', 'Set language English - United States to active/inactive', 9 /*Boolean*/, 'False', NULL),(2209, 2000 /*Languages*/, 'Language_es-US_Active', 'Set language Spanish - United States to active/inactive', 9 /*Boolean*/, 'False', NULL),(2210, 2000 /*Languages*/, 'Language_es-UY_Active', 'Set language Spanish - Uruguay to active/inactive', 9 /*Boolean*/, 'False', NULL),(2211, 2000 /*Languages*/, 'Language_vi-VN_Active', 'Set language Vietnamese - Vietnam to active/inactive', 9 /*Boolean*/, 'False', NULL),(2212, 2000 /*Languages*/, 'Language_ar-YE_Active', 'Set language Arabic - Yemen to active/inactive', 9 /*Boolean*/, 'False', NULL),(2213, 2000 /*Languages*/, 'Language_en-ZW_Active', 'Set language English - Zimbabwe to active/inactive', 9 /*Boolean*/, 'False', NULL)
GO


