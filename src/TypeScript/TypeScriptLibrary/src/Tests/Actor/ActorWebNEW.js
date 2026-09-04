"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ActorWebNew = void 0;
//import { toDateTime } from '../../Algorithms/OrbitalForecastCalculation/OrbitalData';
const ComposionAct_1 = require("../Wrappers/ComposionAct");
const CompositionEvent_1 = require("../Wrappers/CompositionEvent");
function finish(e) {
    console.log(e);
    /* rl.question('Is this example useful? [y/n] ', (answer) => {
          switch (answer.toLowerCase()) {
              case 'y':
                  console.log('Super!');
                  break;
              case 'n':
                  console.log('Sorry! :(');
                  break;
              default:
                  console.log('Invalid answer!');
          }
       //   rl.close();
     // });
     */
}
class ActorWebNew {
    finish(e) {
        /*   rl.question('Is this example useful? [y/n] ', (answer) => {
               switch (answer.toLowerCase()) {
                   case 'y':
                       console.log('Super!');
                       break;
                   case 'n':
                       console.log('Sorry! :(');
                       break;
                   default:
                       console.log('Invalid answer!');
               }
               rl.close();
           });*/
    }
    actCompositionAct() {
        var comp = new ComposionAct_1.CompositionAct();
        comp.test();
    }
    actCompositionEvent(engine) {
        var comp = new CompositionEvent_1.CompositionEvent(engine);
        comp.test();
    }
}
exports.ActorWebNew = ActorWebNew;
