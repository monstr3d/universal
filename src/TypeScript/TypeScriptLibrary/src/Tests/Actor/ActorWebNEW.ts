
import { IDataConsumer } from '../../Library/Measurements/Interfaces/IDataConsumer';
import { RungeProcessor } from '../../Library/Measurements/DifferentialEquations/Processors/RungeProcessor';
import { DataRuntimeConsumerODE } from '../../Library/Runtime/DataRuntimeConsumerODE';
//import { toDateTime } from '../../Algorithms/OrbitalForecastCalculation/OrbitalData';
import { CompositionAct } from '../Wrappers/ComposionAct';
import { CompositionEvent } from '../Wrappers/CompositionEvent';

import { PerformerMeasuremets } from '../../Library/Measurements/PerformerMeasuremets';
import { Composition } from '../Composition';
import { IFunc } from '../../Library/Interfaces/IFunc';
import { IPlayEngine } from '../../Library/Interfaces/IPlayEngine';



function finish(e : any) {
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
export class ActorWebNew {
    finish(e : any): void {
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

 
    public actCompositionAct() {
        var comp = new CompositionAct()
        comp.test();

    }

  
    public actCompositionEvent(engine: IPlayEngine) {
        var comp = new CompositionEvent(engine)
        comp.test();

    }
}
