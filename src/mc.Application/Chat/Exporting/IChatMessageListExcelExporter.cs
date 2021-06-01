using System.Collections.Generic;
using Abp;
using mc.Chat.Dto;
using mc.Dto;

namespace mc.Chat.Exporting
{
    public interface IChatMessageListExcelExporter
    {
        FileDto ExportToFile(UserIdentifier user, List<ChatMessageExportDto> messages);
    }
}
