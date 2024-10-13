mergeInto(LibraryManager.library, {
	getUserId: function () {
		return GameInstance.Module.StrToMemoryBuffer(window.Telegram.WebApp.initDataUnsafe.user.id);
	}
});