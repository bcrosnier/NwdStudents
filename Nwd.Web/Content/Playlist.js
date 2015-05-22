(function (jQuery, nwd) {
    'use strict';
    var $ = jQuery;
    if (!$) { throw new Error('jQuery is required.'); }

    nwd = nwd || {};

    nwd.miniPlayerUrl = '@Url.Action( "MiniPlayer" )';

    nwd.audioElm = $('#albumPlayer')[0];
    nwd.getMiniPlayerFor = function (albumId, trackId) {
        return $.ajax(nwd.miniPlayerUrl, {
            data: {
                albumId: albumId,
                trackId: trackId
            }
        });
    };

    nwd.changeTrackUrl = function (newUrl) {
        $(nwd.audioElm).attr('src', newUrl);
        console.log('Playing:', newUrl);
        nwd.audioElm.play();
    };

    window.nwd = nwd;
}(jQuery, nwd))
