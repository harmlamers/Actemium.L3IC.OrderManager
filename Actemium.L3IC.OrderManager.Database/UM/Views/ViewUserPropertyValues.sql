
CREATE VIEW [UM].[ViewUserPropertyValues]
AS
SELECT        UM.Properties.Id AS PropertyId, UM.Properties.Name, UM.Properties.DefaultValue, UM.Properties.DataType, UM.UserPropertyValues.UserId, 
                         UM.UserPropertyValues.Value
FROM            UM.Properties LEFT OUTER JOIN
                         UM.UserPropertyValues ON UM.Properties.Id = UM.UserPropertyValues.PropertyId
WHERE        (UM.Properties.Type = 1)