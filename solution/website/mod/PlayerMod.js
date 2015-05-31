function startVideo() {
    var url = 'http://dev.dashproject.com.ua/handlers/MediaController.ashx?mid=12&type=mpd',
        video,                                                       
        context,
        player;

    video = document.querySelector('.dash-player video');
    context = new Dash.di.DashContext();
    player = new MediaPlayer(context);

    player.startup();

    player.attachView(video);
    player.setAutoPlay(true);

    player.attachSource(url);
}

$(document).ready(function () {
    startVideo();
});