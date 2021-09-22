function solve() {
    return {
        hasClima: (myCar) => {
            myCar.temp = 21,
                myCar.tempSettings = 21,
                myCar.adjustTemp = () => {
                    if (myCar.temp < myCar.tempSettings) {
                        myCar.temp += 1;
                    } else if (myCar.temp > myCar.tempSettings) {
                        myCar.temp -= 1;
                    }
                }
        },

        hasAudio: (myCar) => {
            myCar.currentTrack = {},
                myCar.currentTrack.name = '',
                myCar.currentTrack.artist = '',
                myCar.nowPlaying = () => {
                    if (myCar.currentTrack !== null) {
                        console.log(`Now playing '${currentTrack.name}' by ${currentTrack.artist}`)
                    }
            }
        },

        hasParktronic: (myCar) => {
            myCar.checkDistance = (distance) => {
                if (distance < 0.1) {
                    console.log("Beep! Beep! Beep!");
                } else if (distance >= 0.1 && distance < 0.25) {
                    console.log("Beep! Beep!");
                } else if (distance >= 0.25 && distance < 0.5) {
                    console.log("Beep!");
                } else {
                    console.log(String.empty)
                }
            }
        }
    }
}