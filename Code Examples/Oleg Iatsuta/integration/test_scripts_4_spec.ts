import {Common} from "../pageObjects/CommonClass";
import {LoginPage} from "../pageObjects/LoginPageClass";
import {Config} from "../common/ConfigClass";
import {JobDetailsPage} from "../pageObjects/JobDetails/JobDetailsPage";
import {ModuleMenu} from "../pageObjects/JobDetails/ModuleMenu";
import {ExpectedServicesPopup} from "../pageObjects/JobDetails/ExpectedServicesPopup";
import {InterpreterSection} from "../pageObjects/JobDetails/InterpreterSection";

describe('Job Details - Adding Expected services', () => {
    before(() => {
        new LoginPage().doLogin();
    })

    let jobDetailsPage: JobDetailsPage;

    it('1. Expected Services popup is opened', () => {
        cy.visit('JobDetail/Index?jobId=' + Config.jobId);
        Common.WaitForSpinnerToOff();

        jobDetailsPage = new JobDetailsPage();
        jobDetailsPage.expectedServicesButton().click();
        Common.WaitForSpinnerToOff();
    })

    let expectedServicesPopup: ExpectedServicesPopup;

    it('2. R services icon is enabled', () => {
        expectedServicesPopup = new ExpectedServicesPopup();

        expectedServicesPopup.reportingService().then( ($reportingServiceButton) => { if(!$reportingServiceButton.hasClass('checked')) $reportingServiceButton.click();});
        expectedServicesPopup.ensureReportingServiceChecked();
    })

    it('3. V services icon is enabled', () => {
        expectedServicesPopup.videographerService().then( ($videographerServiceButton) => { if(!$videographerServiceButton.hasClass('checked')) $videographerServiceButton.click();});
    })

    it('4. I services icon is enabled', () => {
        expectedServicesPopup.interpreter().then( ($interpreterServiceButton) => { if(!$interpreterServiceButton.hasClass('checked')) $interpreterServiceButton.click();});
    })

    it('5. "TSG supplies" radiobutton is enabled', () => {
        var interpreterSection = new InterpreterSection(expectedServicesPopup);
        interpreterSection.tsgSuppliesRadioButton().first().scrollIntoView();
        interpreterSection.tsgSuppliesRadioButton().click({force:true});
    })

    it('6. Click update button', () => {
        expectedServicesPopup.updateButton().click();
    })

    it('7. Click save button', () => {
        jobDetailsPage.saveButton().click();
        Common.WaitForSpinnerToOff();
    })

    it('8. Click M button. R, V, I calendar workflows are started', () => {
        const moduleMenu  = new ModuleMenu(jobDetailsPage);
        moduleMenu.manageButton().click();
        // how to check? -> Ensure that R, V, I calendar workflows are started
    })

    // ASKME
    //     new JobDetailsPage.ModuleMenu().ensureIsOnOrdersButton();
    //     new OrdersSection().addOrderButton().click();
    //     Common.waitForSpinnerToOff();
    //     AddOrderPopup.selectFirstFirm();
    //     AddOrderPopup.updateButton().click();
})
