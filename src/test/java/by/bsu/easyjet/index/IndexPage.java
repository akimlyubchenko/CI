package by.bsu.easyjet.index;

import org.openqa.selenium.Keys;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.PageFactory;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

public class IndexPage {
    private final WebDriver driver;

    private HotelCalendar hotelCalendar;
    private int timeout;

    @FindBy(xpath = "//label[@for='one-way']")
    private WebElement oneWayCheckbox;
    @FindBy(xpath = "//div[contains(@class, 'return-date-picker')]")
    private WebElement returnDateInputField;
    @FindBy(xpath = "//input[starts-with(@id, 'origin-')]")
    private WebElement originInput;
    @FindBy(xpath = "//input[starts-with(@id, 'destination-')]")
    private WebElement destinationInput;
    @FindBy(xpath = "//input[starts-with(@id, 'Adults-')]")
    private WebElement adultNumberInput;
    @FindBy(xpath = "//input[starts-with(@id, 'Children-')]")
    private WebElement childrenNumberInput;
    @FindBy(xpath = "//button[contains(@class, 'search-submit')]")
    private WebElement submitButton;
    @FindBy(xpath = "//form[@name='searchPodForm']/*[contains(text(),'Please select a destination')]")
    private WebDriver destinationRequest;
    @FindBy(xpath = "//li[contains(@class, 'tabbed-container-tab')]/a/h3[contains(text(),'Hotels')]")
    private WebElement hotelsTab;
    @FindBy(xpath = "//li[contains(@class, 'tabbed-container-tab')]/a/h3[contains(text(),'Holidays')]")
    private WebElement holidaysTab;
    @FindBy(xpath = "//*[@id='pageWrapper']/main/div/div[1]/section/div[1]/div/div/ul/li[2]/div/iframe")
    WebElement hotelsFrame;
    @FindBy(xpath = "//iframe[@src='//www.easyjet.com/en/holidays/external/api/partial/searchmask-iframe?utm_medium=EN_Homepage&utm_source=easyjet&utm_term=Holidays&utm_content=Holiday&utm_campaign=searchpod']")
    private WebElement hotelidayFrame;
    @FindBy(xpath = "//div[@passenger-type='Adults']/div/div/button[2]")
    private WebElement addAdultButton;
    @FindBy(xpath = "//div[@passenger-type='Adults']/div/div/button[1]")
    private WebElement removeAdultButton;
    @FindBy(xpath = "//div[@passenger-type='Children']/div/div/button[2]")
    private WebElement addChildrenButton;
    @FindBy(xpath = "//div[@passenger-type='Infants']/div/div/button[2]")
    private WebElement addInfantButton;
    @FindBy(xpath = "//h2[@id='drawer-title-max-passengers']")
    private WebElement maxPassangersWarningDrawer;
    @FindBy(xpath = "//h2[@id='drawer-title-too-many-children-for-number-of-adults']")
    private WebElement maxChildrenPerAdultWarningDrawer;
    @FindBy(xpath = "//h2[@id='drawer-title-more-infants-than-adults']")
    private WebElement moreInfantsThanAdultsWarningDrawer;
    @FindBy(xpath = "//div[@data-for='babies']/div[2]/div/a[2]")
    private WebElement holidayInfantsIncrementButton;

    public IndexPage(WebDriver driver, int timeout) {
        this.driver = driver;
        this.timeout = timeout;
        driver.get("https://www.easyjet.com/en/");
        PageFactory.initElements(driver, this);
    }

    public void openHotelsTab() {
        hotelsTab.click();
        driver.switchTo().frame(hotelsFrame);
    }

    public void openHolidaysTab() {
        holidaysTab.click();
        driver.switchTo().frame(hotelidayFrame);
    }

    public void clickOneWay() {
        oneWayCheckbox.click();
    }

    public boolean isReturnDateInputVisible() {
        return returnDateInputField.isDisplayed();
    }

    public void setOriginAirport(String origin) {
        originInput.sendKeys(origin);
    }

    public void setDestinationAirport(String destination) {
        destinationInput.sendKeys(destination);
    }

    public void submitForm() {
        submitButton.click();
    }

    public boolean isDestinationRequestDisplayed() {
        return destinationInput.isDisplayed();
    }

    public void setAdultNumber(int quantity) {
        adultNumberInput.sendKeys(Keys.HOME, Keys.chord(Keys.SHIFT, Keys.END), String.valueOf(quantity));
    }

    public void addAdult() {
        addAdultButton.click();
    }

    public void removeAdult() {
        removeAdultButton.click();
    }

    public boolean isMoreInfantsThanAdultsDrawerVisible() {
        new WebDriverWait(driver, timeout).until(ExpectedConditions.visibilityOf(moreInfantsThanAdultsWarningDrawer));
        return moreInfantsThanAdultsWarningDrawer.isDisplayed();
    }

    public boolean isMaxPassangersWarningDrawerVisible() {
        new WebDriverWait(driver, timeout).until(ExpectedConditions.visibilityOf(maxPassangersWarningDrawer));
        return maxPassangersWarningDrawer.isDisplayed();
    }

    public void addInfant() {
        addInfantButton.click();
    }

    public boolean isMaxInfantPerAdultWarningDrawerVisible() {
        new WebDriverWait(driver, timeout).until(ExpectedConditions.visibilityOf(moreInfantsThanAdultsWarningDrawer));
        return moreInfantsThanAdultsWarningDrawer.isDisplayed();
    }

    public void addChildren() {
        addChildrenButton.click();
    }

    public void setChildrenNumber(int quantity) {
        childrenNumberInput.sendKeys(Keys.HOME, Keys.chord(Keys.SHIFT, Keys.END), String.valueOf(quantity));
    }

    public boolean isChildrenPerAdultWarningDrawerVisible() {
        new WebDriverWait(driver, timeout).until(ExpectedConditions.visibilityOf(maxChildrenPerAdultWarningDrawer));
        return maxChildrenPerAdultWarningDrawer.isDisplayed();
    }

    public void addHollidayInfants(int infantsNumber) {
        for (int i = infantsNumber; i > 0; i--) {
            holidayInfantsIncrementButton.click();
        }
    }

    public HotelCalendar getCalendar() {
        if (hotelCalendar == null) {
            this.hotelCalendar = new HotelCalendar(driver, timeout);
        }
        return hotelCalendar;
    }

    public boolean isHollidayInfantsCanBeAdded() {
        return !holidayInfantsIncrementButton.getAttribute("class").contains("disabled");
    }
}
