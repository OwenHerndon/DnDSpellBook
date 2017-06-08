app.factory("SpellFactory", function ($q, $http, $rootScope) {
    console.log("poop");
    let getSpellsFromAPI = (selectedClass, selectedLevel) => {
        return $q((resolve, reject) => {
            $http.get(`http://www.dnd5eapi.co/api/spells/${selectedClass}/level/${selectedLevel}`)
			.success(function (spellsObject) {
			    let spells = [];
			    Object.keys(spellsObject).forEach(function (key) {
			        spells.push(spellsObject[key]);
			    });
			    resolve(spells[0]);
			})
			.error(function (error) {
			    reject(error);
			});
        });
    };

    return { getSpells: getSpells };


})