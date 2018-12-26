package by.bsu.easyjet.index;

import java.time.LocalDate;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.chrome.ChromeOptions;
import org.testng.Assert;
import org.testng.annotations.AfterClass;
import org.testng.annotations.BeforeClass;
import org.testng.annotations.Test;

public class EasyJetTest {
    WebDriver driver;
    private static final int timeout = 15;

    @Test
    public void isHideReturnDateChoiceAfterOneWayTiketChoice() {
        IndexPage page = new IndexPage(driver, timeout);
        page.clickOneWay();
        Assert.assertFalse(page.isReturnDateInputVisible());
    }

    @Test
    public void isRestrictToMaxAllowedAdultBookingQuantity() {
        IndexPage page = new IndexPage(driver, timeout);
        page.setAdultNumber(40);
        page.addAdult();
        Assert.assertTrue(page.isMaxPassangersWarningDrawerVisible());
    }

    @Test
    public void isRestrictInfantPerAdultQuantity() {
        IndexPage page = new IndexPage(driver, timeout);
        page.addInfant();
        page.addInfant();
        Assert.assertTrue(page.isMaxInfantPerAdultWarningDrawerVisible());
    }

    @Test
    public void isRestrictChildrenPerAdultQuantity() {
        IndexPage page = new IndexPage(driver, timeout);
        page.setChildrenNumber(10);
        page.addChildren();
        Assert.assertTrue(page.isChildrenPerAdultWarningDrawerVisible());
    }

    @Test
    public void preventsBookingWithSameOriginAndDestination() {
        IndexPage page = new IndexPage(driver, timeout);
        page.setOriginAirport("Lublin (LUZ)");
        page.setDestinationAirport("Lublin (LUZ)");
        page.submitForm();
        Assert.assertTrue(page.isDestinationRequestDisplayed());
    }

    @Test
    private void preventsHotelBookingForLongerThanOneYear() {
        IndexPage page = new IndexPage(driver, timeout);
        page.openHotelsTab();
        page.getCalendar().pickHotelCheckInDate(LocalDate.now());
        Assert.assertFalse(page.getCalendar().isCheckOutButtonCanBeClicked(LocalDate.now().plusYears(1L).plusDays(1L)));
    }

    @Test
    private void preventsHotelBookingForLessThanOneDay() {
        IndexPage page = new IndexPage(driver, timeout);
        page.openHotelsTab();
        page.getCalendar().pickHotelCheckInDate(LocalDate.now());
        Assert.assertFalse(page.getCalendar().isCheckOutButtonCanBeClicked(LocalDate.now()));
    }

    @Test
    public void isAbleToBookHotelWithinAllowedRange() {
        IndexPage page = new IndexPage(driver, timeout);
        page.openHotelsTab();
        page.getCalendar().pickHotelCheckInDate(LocalDate.now());
        Assert.assertTrue(page.getCalendar().isCheckOutButtonCanBeClicked(LocalDate.now().plusDays(2L)));
    }

    @Test
    public void isRestrictOnlyOneInfantPerAdultOnHolliday() {
        IndexPage page = new IndexPage(driver, timeout);
        page.openHolidaysTab();
        page.addHollidayInfants(2);
        Assert.assertFalse(page.isHollidayInfantsCanBeAdded());
    }

    @Test
    public void isPreventsInfantWithoutAdult() {
        IndexPage page = new IndexPage(driver, timeout);
        page.addInfant();
        page.removeAdult();
        Assert.assertTrue(page.isMoreInfantsThanAdultsDrawerVisible());
    }

    @BeforeClass
    public void setup() {
        System.setProperty("webdriver.chrome.driver", "src/test/resources/chromedriver.exe");
        ChromeOptions options = new ChromeOptions();
        options.addArguments(
                "--user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.77 Safari/537.36");
        options.addArguments("--start-maximized");
        driver = new ChromeDriver(options);
    }

    @AfterClass
    public void teardown() {
        if (driver != null) {
            driver.quit();
        }
    }
}
