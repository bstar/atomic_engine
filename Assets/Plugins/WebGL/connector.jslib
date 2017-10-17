mergeInto(LibraryManager.library, {

	Receive: function () {

	var json_data = '{"homeTeam":"DAL","awayTeam":"ANA"}';    
	var buffer = _malloc(lengthBytesUTF8(json_data) + 1);
    writeStringToMemory(json_data, buffer);
    return buffer;	
	},

	Send: function (str) {
	// Send to api
	console.log(Pointer_stringify(str));
	window.alert(Pointer_stringify(str));
	window.alert("test");
	},

});