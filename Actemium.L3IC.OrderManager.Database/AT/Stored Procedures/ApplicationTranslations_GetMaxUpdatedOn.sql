
CREATE PROCEDURE [AT].[ApplicationTranslations_GetMaxUpdatedOn]
(
    @retval datetime OUTPUT
)
AS
select @retval = [Date]
from ApplicationTranslationsUpdatedOn