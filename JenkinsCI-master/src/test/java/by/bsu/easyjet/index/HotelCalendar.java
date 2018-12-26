package by.bsu.easyjet.index;

import java.time.LocalDate;
import java.time.temporal.TemporalAdjusters;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.PageFactory;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

public class HotelCalendar {
    private WebDriver driver;
    private int timeout;

    public HotelCalendar(WebDriver driver, int timeout) {
        this.driver = driver;
        this.timeout = timeout;
        PageFactory.initElements(driver, this);
    }

    @FindBy(xpath = "//div[starts-with(@aria-label,'Check-in.')]")
    private WebElement CheckInCalendar;

    @FindBy(xpath = "//div[starts-with(@aria-label,'Check-out.')]")
    private WebElement CheckOutCalendar;

    @FindBy(xpath = "//*[@id='frm']/div[1]/div[2]/label[1]/h3")
    private WebElement openCheckInCalendarButton;

    @FindBy(xpath = "//*[@id='frm']/div[1]/div[2]/label[2]/h3")
    private WebElement openCheckOutCalendarButton;

    @FindBy(xpath = "//*[@id='ui-datepicker-div']/div[1]/a[2]")
    private WebElement nextMonthButton;

    public void pickHotelCheckInDate(LocalDate date) {
        openCheckInCalendar();
        driver.findElement(By.xpath("//*[@id='ui-datepicker-checkInDate-" + date.getYear() + "-"
                + (date.getMonthValue() - 1) + "-" + date.getDayOfMonth() + "']/a")).click();
    }

    public void pickCheckOutDate(LocalDate date) {
        openCheckOutCalendar();
        scrollCheckOutCalendarToLaterDate(date);
        driver.findElement(By.xpath("//*[@id='ui-datepicker-checkOutDate-" + date.getYear() + "-"
                + (date.getMonthValue() - 1) + "-" + date.getDayOfMonth() + "']/a")).click();
    }

    public boolean isCheckOutButtonCanBeClicked(LocalDate date) {
        openCheckOutCalendar();
        scrollCheckOutCalendarToLaterDate(date);
        new WebDriverWait(driver, timeout).until(ExpectedConditions.visibilityOf(CheckOutCalendar));
        return driver.findElement(By.xpath("//*[@id='ui-datepicker-checkOutDate-" + date.getYear() + "-"
                + (date.getMonthValue() - 1) + "-" + date.getDayOfMonth() + "']/*")).getTagName().equals("a");
    }

    private void openCheckInCalendar() {
        new WebDriverWait(driver, timeout).until(ExpectedConditions.visibilityOf(openCheckInCalendarButton));
        openCheckInCalendarButton.click();
        new WebDriverWait(driver, timeout).until(ExpectedConditions.visibilityOf(CheckInCalendar));
    }

    private void openCheckOutCalendar() {
        new WebDriverWait(driver, timeout).until(ExpectedConditions.visibilityOf(openCheckOutCalendarButton));
        openCheckOutCalendarButton.click();
        new WebDriverWait(driver, timeout).until(ExpectedConditions.visibilityOf(CheckOutCalendar));
    }

    private void scrollCheckOutCalendarToLaterDate(LocalDate date) {
        LocalDate current = LocalDate.now();
        while (current.getYear() < date.getYear()) {
            new WebDriverWait(driver, timeout).until(ExpectedConditions.visibilityOf(CheckOutCalendar));
            nextMonthButton.click();
            current = current.with(TemporalAdjusters.firstDayOfNextMonth());
        }
        while (current.getMonthValue() < date.getMonthValue()) {
            new WebDriverWait(driver, timeout).until(ExpectedConditions.visibilityOf(CheckOutCalendar));
            nextMonthButton.click();
            current = current.with(TemporalAdjusters.firstDayOfNextMonth());
        }
    }
}
