export class JobDetailsPage {
    baseElement = () => cy.get("div.layout-header-section div.header .title:contains('Job Detail')").parent().parent().parent();
    
    saveButton = () => cy.get("button[data-test='save-job-btn']").click();
    expectedServicesButton = () => this.baseElement().find(".tabs-buttons button:contains('Expected Services')");

    //Client Info
    clientInfoToggleSwitch = () => cy.get('div[data-test="jobdetail-clientinfo-container"]').find('.toggle-switch');
    clientInfoToggleSwitchIsOff = () => this.clientInfoToggleSwitch().should('not.have.class', 'toggle-switch checked');
    clientInfoToggleSwitchIsOn = () => this.clientInfoToggleSwitch().should('have.class', 'toggle-switch checked');
    clientInfoShedulingFirmInput = () => cy.get("input[class='clr clientname  autocomplete-input']");

    //Case Info
    caseInfoDateInput = () => cy.get("input[class='caseDate input-datepicker']");
    caseInfoCaseNameInput = () => cy.get("input[class='caseName autocomplete-input']");
}
