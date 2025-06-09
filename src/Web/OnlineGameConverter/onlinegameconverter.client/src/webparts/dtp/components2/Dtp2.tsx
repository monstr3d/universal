import * as React from 'react';
import styles from './Dtp2.module.scss';
import 'bootstrap/dist/css/bootstrap.min.css'; 
import { IDtpProps2 } from "./IDtpProps2";
import { escape } from '@microsoft/sp-lodash-subset'; 
import Comp1 from './Comp1';
import Comp2 from './Comp2';
import Comp3 from './Comp3';

export default class Dtp extends React.Component<IDtpProps2, {}> {
  public render(): React.ReactElement<IDtpProps2> {
    return (
      <div className={ styles.dtp }>
        <div className={ styles.container }>
          <div className={ styles.row }>
            <div className={ styles.column }>
              <span className={ styles.title }>Welcome to SharePoint!</span>
              <p className={ styles.subTitle }>Customize SharePoint experiences using Web Parts.</p>
              <p className={ styles.description }>{escape(this.props.description)}</p>
                            
                            <div>
                            <label> Choose a component:</label>
                            <select id="comp">
                                <option value="datepicker">Date</option>
                                <option value="timepicker">Time</option>
                                <option value="datetimepicker">Date and Time</option>
                            </select>
                            <div id="root"></div>
                            <div id="date"></div>
                            <div id="time"></div>
                            <div id="datetime"></div>

                            <script>
                            function myComponent() 
                            {
                                var x = document.getElementById("comp").selectedIndex;
                            }

                            switch(x)
                            {
                                case 1:
    
                                    document.getElementById("date") = <Comp1 />
                                    break;
                                    
                                case 2:
                                    
                                    document.getElementById("time") = <Comp2 />
                                    break;
                                    
                                case 3:
                                    
                                    document.getElementById("datetime") = <Comp3 />
                                    break;
                                        
                            }
                            </script>
              </div>
            </div>
          </div>
        </div>
      </div>
    );
  }
}
