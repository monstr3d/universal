import * as React from 'react';
import styles from './Dtp.module.scss';
import 'bootstrap/dist/css/bootstrap.min.css'; 
import { IDtpProps } from './IDtpProps';
import { escape } from '@microsoft/sp-lodash-subset'; 
import CustomDateTimePicker from "./CustomDateTimePicker";


export default class Dtp extends React.Component<IDtpProps, object> {
  public render(): React.ReactElement<IDtpProps> {
    return (
      <div className={ styles.dtp }>
        <div className={ styles.container }>
          <div className={ styles.row }>
            <div className={ styles.column }>
              <span className={ styles.title }>Welcome to SharePoint!</span>
              <p className={ styles.subTitle }>Customize SharePoint experiences using Web Parts.</p>
              <p className={ styles.description }>{escape(this.props.description)}</p>
              <div>
                <label className={ styles.label }>Date Selected:</label>
                <CustomDateTimePicker timePicker={false} dateTimePicker={false} className={styles.DP}></CustomDateTimePicker>
                </div>
            </div>
          </div>
        </div>
      </div>
    );
  }
}
