//window.getLongitude = async () => {
//    const pos = await new Promise((resolve, reject) => {
//        navigator.geolocation.getCurrentPosition(resolve, reject);
//    });

//    return pos.coords.longitude;
//};

//window.getLatitude = async () => {
//    const pos = await new Promise((resolve, reject) => {
//        navigator.geolocation.getCurrentPosition(resolve, reject);
//    });

//    return pos.coords.latitude;
//};

window.getCoords = async () => {
    const pos = await new Promise((resolve, reject) => {
        navigator.geolocation.getCurrentPosition(resolve, reject);
    });

    //return [pos.coords.longitude, pos.coords.latitude];
    return pos.coords.latitude + ',' + pos.coords.longitude

};
