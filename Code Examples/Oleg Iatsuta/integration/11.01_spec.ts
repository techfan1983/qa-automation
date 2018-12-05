import {LoginPage} from "../pageObjects/LoginPageClass";
import {Common} from "../pageObjects/CommonClass";
import {Config} from "../common/ConfigClass";
import {JobDetailsPage} from "../pageObjects/JobDetails/JobDetailsPage";

describe('11.01 - Client Matter # TBD Slider', () => {
    let jobId = Config.jobId;
    let firmName = Config.firmName;
    let date = Config.date;
    let caseName = Config.caseName;
    let jobDetailsPage = new JobDetailsPage();
    before(() => {
        new LoginPage().doLogin();
    })
    it('Preconditions: \
        1. Create a new job; \
        2. Add a scheduling firm.', () => {
        Common.createJob();
        Common.WaitForSpinnerToOff();
        jobDetailsPage.clientInfoShedulingFirmInput().type(firmName + '{downarrow}{enter}'); //FIXME
    })
    it('1. TBD Slider appears next to the Client Matter # and that it is off by default', () => {
        jobDetailsPage.clientInfoToggleSwitchIsOff();
    })
    it('2. Slider should toggle off and on.', () => {
        jobDetailsPage.clientInfoToggleSwitch().click({ force: true });
        jobDetailsPage.clientInfoToggleSwitchIsOn();
        jobDetailsPage.clientInfoToggleSwitch().click({ force: true });
        jobDetailsPage.clientInfoToggleSwitchIsOff();
    })
    it('3. Job is saved with active TBD switch for Client Matter #', () => {
        jobDetailsPage.caseInfoDateInput().type(date);
        jobDetailsPage.caseInfoCaseNameInput().type(caseName);
        jobDetailsPage.clientInfoToggleSwitch().click({ force: true });
        jobDetailsPage.saveButton().click();
    })
})