var app = angular.module('weather', ["leaflet-directive"]);

app.controller("LayersSimpleController", [ '$scope', function($scope) {
    angular.extend($scope, {
        denver: {
            lat: 39.73915,
            lng: -104.9847,
            zoom: 6
        },
        layers: {
            baselayers: {
                osm: {
                    name: 'OpenStreetMap',
                    url: 'http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png',
                    type: 'xyz'
                }                
            },
            overlays: {
                precipitation: {
                    name: 'OpenWeatherMap - Precipitation',
                    type: 'xyz',
                    url: 'http://{s}.tile.openweathermap.org/map/precipitation/{z}/{x}/{y}.png',
                    visible: true,
                    layerOptions: {
                        opacity:0.5
                    }
                }
            }
        },
        defaults: {
            scrollWheelZoom: false
        }
    });

    $scope.setLocation = function(lat,lon) {
        //alert(lat + ":" + lon);
        this.denver.lat = parseFloat(lat);
        this.denver.lng = parseFloat(lon);
        this.denver.zoom = 7;
    };
} ]);

app.controller('FormController', ['$scope', '$http', function($scope,$http){
    this.locationInput = "";
    
    $scope.updateLocation = function () {
        // preform a http.get to grab the new location
        var replacedInput = this.locationInput.replace(/ /g, '+');
        var url ="http://nominatim.openstreetmap.org/search?q="+replacedInput+"&format=json&polygon=0&addressdetails=0&limit=1"
        
        $http.get(url).success( function(data) {
            $scope.setLocation(data[0].lat,data[0].lon);
        });
        
    };
}]);