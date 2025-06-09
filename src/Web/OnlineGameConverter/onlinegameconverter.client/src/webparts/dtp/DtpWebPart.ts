import * as React from 'react';
import * as ReactDom from 'react-dom';
import { Version } from '@microsoft/sp-core-library';
import { IPropertyPaneConfiguration,PropertyPaneTextField } from '@microsoft/sp-property-pane';
import { BaseClientSideWebPart } from '@microsoft/sp-webpart-base';
import * as strings from 'DtpWebPartStrings';

// 1)component is imported here
import Dtp from './components/Dtp';
// 2)component's props being imported here
import { IDtpProps } from './components/IDtpProps';
// 3)wiring the component
export interface IDtpWebPartProps {
  description: string;
}

export default class DtpWebPart extends BaseClientSideWebPart <IDtpWebPartProps> {

  public render(): void {
    const element: React.ReactElement<IDtpProps> = React.createElement(
      Dtp,
      {
        description: this.properties.description
      }
    );

    ReactDom.render(element, this.domElement);
  }

  protected onDispose(): void {
    ReactDom.unmountComponentAtNode(this.domElement);
  }

  protected get dataVersion(): Version {
    return Version.parse('1.0');
  }

  protected getPropertyPaneConfiguration(): IPropertyPaneConfiguration {
    return {
      pages: [
        {
          header: {
            description: strings.PropertyPaneDescription
          },
          groups: [
            {
              groupName: strings.BasicGroupName,
              groupFields: [
                PropertyPaneTextField('description', {
                  label: strings.DescriptionFieldLabel
                })
              ]
            }
          ]
        }
      ]
    };
  }
}
