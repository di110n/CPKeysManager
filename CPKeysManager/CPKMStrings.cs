using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPKeysManager
{
    class CPKMStrings
    {
        public const string txtErrCantReadReg = "ОШИБКА! Невозможно прочитать ключ реестра. Путь: ";
        public const string txtErrNoKeysToAction = "ОШИБКА! Не выбрано ни одного контейнера для работы!";
        public const string txtErrNoUsersToCopyKeys = "ОШИБКА! Не выбрано ни одного пользователя для копирования выбранных контейнеров!";
        public const string txtErrNoUsersToDeleteKeys = "ОШИБКА! Не выбрано ни одного пользователя для удаления выбранных контейнеров!";
        public const string txtErrNoUsersToInstallCrt = "ОШИБКА! Не выбрано ни одного пользователя для установки сертификатов в выбранных контейнерах!";
        public const string txtErrNoRegistryPath = "ОШИБКА! Не найден только что созданный ключ для контейнера. Путь: ";

        public const string txtMsgSourceUser = "Выбран список контейнеров пользователя ";
        public const string txtMsgSelectUserToCopyKeys = "Выберите пользователя для копирования контейнеров";
        public const string txtMsgSelectUserToDeleteKeys = "Выберите пользователя для удаления контейнеров";
        public const string txtMsgSelectUserToInstallCrt = "Выберите пользователя для установки сертификатов";
        public const string txtMsgCopyKeysForUser = "Копируем выбранные контейнеры пользователю ";
        public const string txtMsgDeleteKeysForUser = "Удаляем выбранные контейнеры у пользователя ";
        public const string txtMsgInstallingCrtsForUser = "Устанавливаем сертификаты из выбранных контейнеров пользователю ";
        public const string txtDone = "Готово!";
        public const string txtUser = "пользователь";
        public const string txtMsgNotSignedIn = "не вошел в систему";
        public const string txtSelectedContainers = "Выбрано контейнеров:";

        public const string txtError = "ОШИБКА";
        public const string txtSuccess = "УСПЕШНО";

    }
}
