mergeInto(LibraryManager.library, {

  ShowAds : function(){
    ysdk.adv.showFullscreenAdv({
    callbacks: {
        onClose: function(wasShown) {
          console.log("---------closed-----------");
          SendMessage('Ads', 'OnCloseAdvertisemnt');
        },
        onError: function(error) {
          // some action on error
          console.log("---------error-----------");
        }
    }
})
  },


  ShowCoreGamePixelVersion : function(scene){
    ysdk.adv.showRewardedVideo({
    callbacks: {
        onOpen: () => {
          console.log('Video ad open.');
                    SendMessage('Ads', 'PauseGameAndAudio');

        },
        onRewarded: () => {
          console.log('Rewarded!');
          SendMessage('PlayButtonPixelVersion', 'LoadScene', "CoreGame");
        },
        onClose: () => {
          console.log('Video ad closed.');
          SendMessage('Ads', 'OnCloseAdvertisemnt');

        }, 
        onError: (e) => {
          console.log('Error while open video ad:', e);
        }
    }
})
  },

    ShowSkinShop : function(scene){
    ysdk.adv.showRewardedVideo({
    callbacks: {
        onOpen: () => {
          console.log('Video ad open.');
                    SendMessage('Ads', 'PauseGameAndAudio');

        },
        onRewarded: () => {
          console.log('Rewarded!');
          SendMessage('OpenSkinShopButton', 'LoadScene', "SkinShop");
        },
        onClose: () => {
          console.log('Video ad closed.');
          SendMessage('Ads', 'OnCloseAdvertisemnt');

        }, 
        onError: (e) => {
          console.log('Error while open video ad:', e);
        }
    }
})
  },

  SetSkinGirl : function(scene){
    ysdk.adv.showRewardedVideo({
    callbacks: {
        onOpen: () => {
          console.log('Video ad open.');
          SendMessage('Ads', 'PauseGameAndAudio');

        },
        onRewarded: () => {
          console.log('Rewarded!');
          SendMessage('SkinManager', 'Save');
          SendMessage('ConfirmButton', 'LoadScene', "MainMenu");

        },
        onClose: () => {
          console.log('Video ad closed.');
          SendMessage('Ads', 'OnCloseAdvertisemnt');

        }, 
        onError: (e) => {
          console.log('Error while open video ad:', e);
        }
    }
})
  },
 
});